using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Data
{
    public class DbInitializer
    {
        public static void Initialize(ssdticketsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Venue.Any())
            {
                // DB has already been seeded
                return;
            }

            // Initialization constants
            const string VENUE_NAME = "BCIT Stadium";

            const int NUM_SECTIONS = 10;
            const int ROWS_PER_SECTION = 10;
            const int SEATS_PER_ROW = 10;
            const int CAPACITY = NUM_SECTIONS * ROWS_PER_SECTION * SEATS_PER_ROW;

            const decimal VENUE_SEAT_PRICE = 12.50m;

            // Venue
            Venue bcit = new Venue { Capacity = CAPACITY, VenueName = VENUE_NAME };
            context.Venue.Add(bcit);
            context.SaveChanges();

            // Sections
            List<Section> sections = new List<Section>();
            for (int i = 0; i < NUM_SECTIONS; i++)
            {
                var section = new Section
                {
                    VenueName = bcit.VenueName,
                    SectionName = $"Section {i + 1}"
                };

                sections.Add(section);
                context.Section.Add(section);
            }
            context.SaveChanges();

            // Rows
            List<Row> rows = new List<Row>();
            foreach (Section s in sections)
            {
                for (int i = 0; i < ROWS_PER_SECTION; i++)
                {
                    var row = new Row { Section = s, RowName = $"Row {i + 1}" };
                    rows.Add(row);
                    context.Row.Add(row);
                }
                context.SaveChanges();
            }

            // Seats
            List<Seat> seats = new List<Seat>();
            foreach (Row r in rows)
            {
                for (int i = 0; i < SEATS_PER_ROW; i++)
                {
                    var seat = new Seat { Row = r, Price = VENUE_SEAT_PRICE };
                    seats.Add(seat);
                    context.Seat.Add(seat);
                }
                context.SaveChanges();
            }

            // Events
            var events = new Event[] {
                new Event { EventName = "Conference", VenueName = VENUE_NAME },
                new Event { EventName = "Barbecue", VenueName = VENUE_NAME },
                new Event { EventName = "Hackathon", VenueName = VENUE_NAME },
                new Event { EventName = "Convention", VenueName = VENUE_NAME },
                new Event { EventName = "Soccer Championships", VenueName = VENUE_NAME }
            };
            foreach (Event e in events)
            {
                context.Event.Add(e);
            }
            context.SaveChanges();

            // Event Seats
            // Prices for events are 10.50, plus an extra $5 for each row closer to the front
            //   (eg. if there are 10 rows, the 10th row will have no extra cost, and the 1st row will be an extra $45)
            foreach (Event e in events)
            {
                decimal eventPrice = 10.50m;

                foreach (Seat venueSeat in seats)
                {
                    var eventSeat = new EventSeat { 
                        Seat = venueSeat,
                        Event = e,
                        EventSeatPrice = eventPrice + (5 * (ROWS_PER_SECTION - getRowNumber(venueSeat.Row)))
                    };
                    context.EventSeat.Add(eventSeat);
                }
                context.SaveChanges();
            }

            // Ticket Purchases
            // Each event has the first row of section 1 sold out
            // Each event also has seats 1 and 2 sold in the second row of section 1
            foreach (Event e in events)
            {
                // Purchase first row in a single transaction
                IEnumerable<EventSeat> firstRow = e.EventSeat.Where(es => getRowNumber(es.Seat.Row) == 1 && es.Seat.Row.SectionId == 1);
                var firstRowPurchase = new TicketPurchase { PaymentMethod = "Credit Card", ConfirmationCode = "123456" };
                decimal totalPurchaseCost = 0;

                var tickets = new List<TicketPurchaseSeat>();
                foreach (EventSeat es in firstRow)
                {
                    var seatPurchase = new TicketPurchaseSeat { 
                        EventSeat = es,
                        Purchase = firstRowPurchase,
                        SeatSubtotal = es.EventSeatPrice + es.Seat.Price
                    };
                    tickets.Add(seatPurchase);
                    totalPurchaseCost += (decimal) seatPurchase.SeatSubtotal;
                }

                firstRowPurchase.PaymentAmount = totalPurchaseCost;
                context.TicketPurchase.Add(firstRowPurchase);
                context.SaveChanges();

                foreach (TicketPurchaseSeat ticket in tickets)
                {
                    context.TicketPurchaseSeat.Add(ticket);
                }
                context.SaveChanges();

                // Purchase seats 1 and 2 of second row
                IEnumerable<EventSeat> secondRowSeats = e.EventSeat.Where(
                    es => getRowNumber(es.Seat.Row) == 2 && es.Seat.Row.SectionId == 1 && (es.SeatId % SEATS_PER_ROW == 1 || es.SeatId % SEATS_PER_ROW == 2));
                var secondRowPurchase = new TicketPurchase { PaymentMethod = "Debit", ConfirmationCode = "789123" };
                totalPurchaseCost = 0;

                tickets = new List<TicketPurchaseSeat>();
                foreach (EventSeat es in secondRowSeats)
                {
                    var seatPurchase = new TicketPurchaseSeat
                    {
                        EventSeat = es,
                        Purchase = secondRowPurchase,
                        SeatSubtotal = es.EventSeatPrice + es.Seat.Price
                    };
                    tickets.Add(seatPurchase);
                    totalPurchaseCost += (decimal)seatPurchase.SeatSubtotal;
                }

                secondRowPurchase.PaymentAmount = totalPurchaseCost;
                context.TicketPurchase.Add(secondRowPurchase);
                context.SaveChanges();

                foreach (TicketPurchaseSeat ticket in tickets)
                {
                    context.TicketPurchaseSeat.Add(ticket);
                }
                context.SaveChanges();
            }
        }


        // helpers
        static private int getRowNumber(Row r)
        {
            return Int32.Parse(r.RowName.Split(' ')[1]);
        }
    }
}
