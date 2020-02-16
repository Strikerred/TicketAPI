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
            }
            context.SaveChanges();

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
            }
            context.SaveChanges();


        }
    }
}
