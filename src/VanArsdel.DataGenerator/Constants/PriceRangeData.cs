namespace VanArsdel.DataGenerator.Constants;

public static class PriceRangeData
{

    public static readonly Dictionary<string, (int min, int max)> ProductCategoryPriceRanges =
        new()
        {
            // Living Room
            { "Sofas & Couches", (300, 1600) },
            { "Sectionals", (700, 2500) },
            { "Loveseats", (250, 800) },
            { "Chairs", (100, 700) },
            { "Accent Chairs", (80, 800) },
            { "Recliners", (300, 700) },
            { "Ottomans & Poufs", (30, 250) },
            { "Benches", (50, 300) },
            { "Sleeper Sofas", (400, 1500) },
            { "Futons", (200, 1200) },
            { "Coffee Tables", (20, 350) },
            { "End & Side Tables", (15, 150) },
            { "Console Tables", (70, 300) },
            { "TV Stands & Media Centers", (50, 600) },
            { "Bookcases & Shelving Units", (40, 500) },
            { "Cabinets & Chests", (50, 600) },
            { "Room Dividers", (50, 250) },

            // Bedroom
            { "Beds", (150, 1000) },
            { "Platform Beds", (150, 700) },
            { "Storage Beds", (300, 900) },
            { "Canopy Beds", (300, 600) },
            { "Bunk Beds", (200, 500) },
            { "Headboards", (50, 400) },
            { "Bed Frames", (100, 600) },
            { "Nightstands", (30, 200) },
            { "Dressers & Chests of Drawers", (100, 600) },
            { "Wardrobes & Armoires", (150, 1200) },
            { "Makeup Vanities", (100, 350) },
            { "Bedroom Benches", (60, 250) },
            { "Jewelry Armoires", (100, 300) },

            // Mattresses & Bedding
            { "Mattresses", (100, 1200) },
            { "Mattress Toppers & Pads", (30, 250) },
            { "Mattress Protectors", (15, 60) },
            { "Bed Pillows", (5, 70) },
            { "Sheets & Pillowcases", (15, 100) },
            { "Comforters & Sets", (20, 150) },
            { "Duvets & Duvet Covers", (25, 120) },
            { "Quilts & Coverlets", (30, 100) },
            { "Bedspreads", (30, 90) },
            { "Blankets & Throws", (10, 60) },
            { "Bed Skirts", (20, 50) },

            // Dining Room
            { "Dining Tables", (80, 700) },
            { "Dining Sets", (200, 1000) },
            { "Dining Chairs", (30, 200) },
            { "Sideboards & Buffets", (150, 600) },
            { "China Cabinets & Hutches", (200, 700) },
            { "Kitchen Islands & Carts", (100, 500) },
            { "Baker's Racks", (80, 250) },

            // Kitchen
            { "Kitchen Storage", (50, 500) },
            { "Pot Racks", (20, 80) },
            { "Pantry Cabinets", (100, 600) },
            { "Trash Bins & Recycling", (10, 100) },

            // Office
            { "Desks", (50, 600) },
            { "Executive Desks", (300, 700) },
            { "Writing Desks", (50, 300) },
            { "Standing Desks", (200, 700) },
            { "Computer Desks", (60, 400) },
            { "Office Chairs", (50, 500) },
            { "Ergonomic Chairs", (150, 500) },
            { "Task Chairs", (50, 200) },
            { "Guest Chairs", (40, 150) },
            { "Bookcases", (40, 500) },
            { "Filing Cabinets", (80, 300) },
            { "Office Storage & Organization", (20, 400) },
            { "Desk Lamps", (10, 70) },

            // Storage & Organization
            { "Storage Benches", (60, 300) },
            { "Wall Shelves", (5, 100) },
            { "Closet Organizers", (50, 1000) },
            { "Shoe Storage", (20, 200) },
            { "Storage Bins & Baskets", (3, 50) },
            { "Hooks & Racks", (5, 50) },
            { "Garage Storage", (50, 500) },

            // Outdoor
            { "Patio Conversation Sets", (300, 1500) },
            { "Outdoor Sofas & Sectionals", (200, 1000) },
            { "Outdoor Lounge Chairs", (50, 300) },
            { "Adirondack Chairs", (80, 200) },
            { "Patio Dining Sets", (150, 800) },
            { "Outdoor Dining Tables", (80, 500) },
            { "Outdoor Dining Chairs", (25, 150) },
            { "Outdoor Bar Furniture", (150, 600) },
            { "Hammocks & Swings", (50, 250) },
            { "Outdoor Benches", (60, 300) },
            { "Chaise Lounges", (80, 400) },
            { "Outdoor Coffee & Side Tables", (30, 150) },
            { "Planters & Garden Decor", (5, 100) },
            { "Fire Pits & Patio Heaters", (100, 400) },

            // Baby & Kids
            { "Cribs", (100, 400) },
            { "Toddler Beds", (80, 250) },
            { "Kids Beds", (100, 500) },
            { "Bunk Beds & Loft Beds", (200, 600) },
            { "Kids Dressers & Chests", (80, 300) },
            { "Kids Nightstands", (30, 100) },
            { "Changing Tables", (80, 250) },
            { "Nursery Gliders & Rocking Chairs", (150, 400) },
            { "Kids Table & Chair Sets", (40, 150) },
            { "Toy Storage", (20, 300) },
            { "Kids Bookcases & Shelving", (30, 150) },
            { "Play Tents & Tunnels", (20, 60) },

            // Entryway
            { "Entryway Benches", (50, 250) },
            { "Hall Trees", (100, 350) },
            { "Coat Racks", (20, 100) },
            { "Doormats", (5, 30) },

            // Bathroom
            { "Bathroom Vanities", (100, 800) },
            { "Bathroom Sinks", (50, 300) },
            { "Medicine Cabinets", (40, 250) },
            { "Bathroom Storage", (30, 300) },
            { "Towel Racks & Stands", (10, 80) },
            { "Shower Curtains & Liners", (10, 40) },
            { "Bathroom Rugs & Mats", (10, 50) },
            { "Laundry Hampers", (15, 60) },

            // Lighting
            { "Ceiling Lights", (15, 200) },
            { "Chandeliers", (50, 300) },
            { "Pendant Lights", (20, 150) },
            { "Flush Mount Lights", (15, 100) },
            { "Track Lighting", (30, 150) },
            { "Floor Lamps", (20, 150) },
            { "Table Lamps", (10, 80) },
            { "Wall Sconces", (15, 80) },
            { "Night Lights", (5, 20) },
            { "String Lights", (10, 50) },
            { "Light Bulbs", (2, 20) },

            // Rugs
            { "Area Rugs", (20, 600) },
            { "Runners", (20, 150) },
            { "Outdoor Rugs", (20, 200) },
            { "Kitchen Mats", (10, 40) },
            { "Bathroom Rugs", (10, 50) },
            { "Kids Rugs", (20, 100) },
            { "Rug Pads", (10, 80) },

            // Decor
            { "Wall Art", (10, 200) },
            { "Paintings", (50, 300) },
            { "Prints", (5, 50) },
            { "Photography", (10, 100) },
            { "Wall Accents", (10, 80) },
            { "Mirrors", (15, 200) },
            { "Clocks", (10, 60) },
            { "Decorative Pillows", (5, 40) },
            { "Throw Blankets", (10, 60) },
            { "Candles & Holders", (2, 30) },
            { "Vases", (3, 50) },
            { "Decorative Bowls & Trays", (5, 40) },
            { "Sculptures & Figurines", (5, 60) },
            { "Picture Frames", (2, 40) },
            { "Plants & Flowers", (5, 70) },
            { "Window Treatments", (10, 100) },

            // Home Improvement
            { "Hardware (Knobs, Pulls)", (2, 20) },
            { "Wallpaper", (30, 60) },
            { "Wall Paneling", (50, 200) },
            { "Flooring (Tiles, Wood)", (2, 10) },
            { "Fireplaces & Accessories", (50, 300) },
            { "Fans (Ceiling, Portable)", (30, 200) },

            // Commercial Furniture
            { "Office Furniture Sets", (500, 3000) },
            { "Reception Desks", (300, 1000) },
            { "Conference Tables", (200, 1000) },
            { "Office Partitions", (100, 400) },
            { "Restaurant Tables & Chairs", (150, 600) },
            { "Bar Furniture", (100, 500) },
            { "Hotel Furniture", (200, 1500) },
            { "Retail Displays & Shelving", (50, 500) },

            // Game Room
            { "Pool Tables", (800, 3000) },
            { "Foosball Tables", (100, 500) },
            { "Air Hockey Tables", (150, 800) },
            { "Poker Tables & Sets", (100, 600) },
            { "Game Tables", (50, 300) },
            { "Gaming Chairs", (100, 400) },
            { "Dartboards & Cabinets", (30, 150) },
            { "Bar & Pub Tables", (80, 350) },
            { "Home Theater Seating", (300, 1500) },

            // Bar Furniture
            { "Home Bar Sets", (200, 800) },
            { "Bar Tables", (80, 350) },
            { "Pub Tables", (70, 300) },
            { "Bar Stools", (40, 200) },
            { "Bar Cabinets", (150, 600) },
            { "Wine Racks", (10, 150) },
            { "Wine Storage", (100, 500) },
            { "Bar Carts", (50, 250) },
            { "Liquor Cabinets", (150, 600) },

            // Pet Furniture
            { "Dog Beds", (10, 60) },
            { "Cat Trees & Condos", (20, 80) },
            { "Pet Crates & Kennels", (50, 150) },
            { "Pet Gates", (30, 80) },
            { "Feeding Stations", (10, 40) },
            { "Pet Steps & Ramps", (20, 60) },

            // Accent Furniture
            { "Accent Tables", (20, 200) },
            { "Accent Cabinets & Chests", (100, 500) },
            { "Étagères & Shelves", (50, 300) },
            { "Trunks", (50, 200) },

            // Laundry & Utility
            { "Utility Cabinets & Sinks", (100, 400) },
            { "Ironing Boards", (10, 80) },
            { "Drying Racks", (10, 60) },
            { "Folding Stations", (50, 150) },
            { "Step Stools", (10, 50) },
            { "Cleaning‑Supply Storage", (30, 150) },

            // Home Fitness & Gym
            { "Weight Benches & Racks", (100, 500) },
            { "Treadmill / Bike Stands", (30, 100) },
            { "Yoga & Mat Storage", (20, 80) },
            { "Multi‑Gym Stations", (400, 2000) },
            { "Fitness Mirrors", (100, 500) },
            { "Gym Flooring Tiles", (2, 6) },

            // Garage & Workshop
            { "Workbenches", (100, 400) },
            { "Tool Cabinets & Chests", (80, 500) },
            { "Wall‑Mounted Storage", (30, 200) },
            { "Utility Shelving", (40, 200) },
            { "Pegboards", (15, 50) },
            { "Bike Racks", (20, 100) },

            // Music & Studio
            { "Studio Desks", (100, 500) },
            { "Speaker Stands", (20, 100) },
            { "Keyboard Stands", (30, 150) },
            { "Instrument Racks & Cabinets", (50, 300) },
            { "Recording Booth Panels", (100, 500) },
            { "Sheet‑Music Storage", (50, 200) },

            // Medical & Accessibility
            { "Lift Chairs", (500, 1500) },
            { "Adjustable Beds", (800, 2500) },
            { "Over‑Bed Tables", (40, 150) },
            { "Shower Seats", (30, 100) },
            { "Grab Bars", (10, 50) },
            { "Walker / Wheelchair Storage", (30, 100) },

            // Event & Folding Furniture
            { "Folding Tables", (30, 150) },
            { "Folding Chairs", (10, 50) },
            { "Stackable Chairs", (15, 60) },
            { "Portable Stages & Risers", (200, 1000) },
            { "Table Carts", (100, 300) },
            { "Chair Dollies", (80, 250) },

            // Seasonal & Holiday
            { "Holiday Trees & Stands", (30, 300) },
            { "Decorative Figurines", (5, 50) },
            { "Seasonal Storage Bins", (5, 40) },
            { "Patio Heaters", (100, 400) },

            // Classroom & Educational
            { "Student Desks", (40, 150) },
            { "Classroom Chairs", (20, 80) },
            { "Activity Tables", (50, 200) },
            { "Storage Cubbies", (40, 250) },
            { "Library Carrels", (150, 400) },
            { "Teacher Desks", (100, 400) },
        };
}