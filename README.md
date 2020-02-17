# Ticketing API

An API for facilitating ticket purchases.

## Seeded Data

### Venue

- 1 Venue named "BCIT Stadium" with a capacity of 1000 seats
- 10 Sections
- Each section has 10 rows
- Each row has 10 seats
- The base price for a venue seat is \$12.50

### Events

- 5 Events named "Conference", "Barbecue", "Hackathon", "Convention", and "Soccer Championships"
- Each event has all 1000 seats allotted as event seats
- The base price for an event seat is $10.50, which increases by $5 for each row closer to the first (i.e. with 10 rows, the first row would be an extra \$45)

### Purchases

- The first row in section 1 has been bought out for each event.
- The first two seats in row 2 of section 1 have also been bought out for each event.

Purchased Event Seat Ids:

1, 658, 659, 660, 661, 662, 663, 664, 665, 666, 667, 668, 1001, 1658, 1659, 1660, 1661, 1662, 1663, 1664, 1665, 1666, 1667, 1668, 2001, 2658, 2659, 2660, 2661, 2662, 2663, 2664, 2665, 2666, 2667, 2668, 3001, 3658, 3659, 3660, 3661, 3662, 3663, 3664, 3665, 3666, 3667, 3668, 4001, 4658, 4659, 4660, 4661, 4662, 4663, 4664, 4665, 4666, 4667, 4668

The code which seeds the database can be found in `Data\DbInitializer.cs`

## Schema Changes

Changed the id of TicketPurchase to be an Identity column

## Endpoints

Most of the endpoints simply provide information about the state of the venue, the events, and the associated seats. Querying for event seats will include the availability of that seat (i.e. whether it has already been purchased or not). Purchases can be registered with the system via a POST request containing the desired seat ids.

The endpoints were designed to support an application which would allow users to browse seats/events, make selections based on which seats are available, and ultimately make a seat purchase.

### GET /venue

- returns an array of venues
- eg. [{venue_name: string, capacity: int}, ...]

### GET /venue/{id}

- returns a venue with {id}
- {venue_name: id, capacity: int}

### GET /section

- return an array of sections
- eg. [{section_id: int, section_name: string}, ...]

### GET /section/{id}

- return a section with {id}
- eg. {section_id: int, section_name: string}

### GET /row/section/{section_id}

- return an array of rows in the section with id {section_id}
- eg. [{row_id: int, row_name: string}, ...]

### GET /row/{id}

- return a single row with {id}
- eg. {row_id:id, row_name: string}

### GET /seat/row/{row_id}

- returns all of the seats in the row with id {row_id}
- eg. [{seat_id: int, price: decimal}, ...]

### GET /seat/{id}

- returns the seat with {id}
- eg. {seat_id: id, price: decimal}

### GET /event

- returns an array of all events
- [{event_id: int, event_name: string, venue_name: string}, ...]

### GET /event/{id}

- returns the event with {id}
- {event_id: id, event_name: string, venue_name: string}

### GET /event-seat/event/{event_id}

- returns an array of all the event seats for an event with {event_id}
- eg. [{event_seat_id: int, event_seat_price: decimal, is_available: bool}, ...]

### GET /event-seat/{id}

- return an event seat with {id}
- {event_seat_id: id, event_seat_price: decimal, is_available: bool}

### GET /seat-purchase

- return an array of all purchased seats
- eg. [{purchase_id: int, event_seat_id: int, seat_subtotal: decimal}, ...]

### GET /seat-purchase/purchase/{purchase_id}

- return all seats purchased for a purchase with {purchase_id}
- eg. [{purchase_id: int, event_seat_id: int, seat_subtotal: decimal}, ...]

### GET /purchase

- returns an array of all purchases made so far
- eg. [{purchase_id: int, payment_method: string, payment_amount: decimal, confirmation_code: int}, ...]

### GET /purchase/{purchase_id}

- returns the purchase with {purchase_id}
- eg. {purchase_id: int, payment_method: string, payment_amount: decimal, confirmation_code: int}

### POST /purchase

- to register a purchase, this endpoint expects a body with the following information

```javascript
{
    seats: [event_seat_id1, event_seat_id2, ...],
    payment_method: "Credit Card" | "Debit Card" | "Cash"
}
```
