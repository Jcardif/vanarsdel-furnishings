namespace VanArsdel.DataGenerator.Constants;

public static class ProductData
{
    // product category definitions
    public static readonly List<(string parent, string[] subs)> ProductCategoryDefinitions = new List<(string Top, string[] Subs)>
    {
        ("Living Room", [
            "Sofas & Couches", "Sectionals", "Loveseats", "Chairs", "Accent Chairs",
            "Recliners", "Chaise Lounges", "Ottomans & Poufs", "Benches",
            "Sleeper Sofas", "Futons", "Coffee Tables", "End & Side Tables",
            "Console Tables", "TV Stands & Media Centers",
            "Bookcases & Shelving Units", "Cabinets & Chests", "Room Dividers"
        ]),

        ("Bedroom", [
            "Beds", "Platform Beds", "Storage Beds", "Canopy Beds", "Bunk Beds",
            "Headboards", "Bed Frames", "Nightstands", "Dressers & Chests of Drawers",
            "Wardrobes & Armoires", "Makeup Vanities", "Bedroom Benches",
            "Jewelry Armoires"
        ]),

        ("Mattresses & Bedding", [
            "Mattresses",
            "Mattress Toppers & Pads", "Mattress Protectors",
            "Bed Pillows", "Sheets & Pillowcases", "Comforters & Sets",
            "Duvets & Duvet Covers", "Quilts & Coverlets", "Bedspreads",
            "Blankets & Throws", "Bed Skirts"
        ]),

        ("Dining Room", [
            "Dining Tables", "Dining Sets", "Dining Chairs",
            "Sideboards & Buffets", "China Cabinets & Hutches",
            "Kitchen Islands & Carts", "Baker's Racks"
        ]),

        ("Kitchen", [
            "Kitchen Storage", "Pot Racks", "Pantry Cabinets",
            "Trash Bins & Recycling"
        ]),

        ("Office", [
            "Desks", "Executive Desks", "Writing Desks", "Standing Desks",
            "Computer Desks", "Office Chairs", "Ergonomic Chairs", "Task Chairs",
            "Guest Chairs", "Bookcases", "Filing Cabinets",
            "Office Storage & Organization", "Desk Lamps"
        ]),

        ("Storage & Organization", [
            "Bookcases & Shelving Units", "Cabinets & Chests", "Storage Benches",
            "Wall Shelves", "Closet Organizers", "Shoe Storage",
            "Storage Bins & Baskets", "Hooks & Racks", "Garage Storage"
        ]),

        ("Outdoor", [
            "Patio Conversation Sets", "Outdoor Sofas & Sectionals",
            "Outdoor Lounge Chairs", "Adirondack Chairs", "Patio Dining Sets",
            "Outdoor Dining Tables", "Outdoor Dining Chairs",
            "Outdoor Bar Furniture", "Hammocks & Swings", "Outdoor Benches",
            "Chaise Lounges", "Outdoor Coffee & Side Tables",
            "Planters & Garden Decor", "Fire Pits & Patio Heaters"
        ]),

        ("Baby & Kids", [
            "Cribs", "Toddler Beds", "Kids Beds", "Bunk Beds & Loft Beds",
            "Kids Dressers & Chests", "Kids Nightstands", "Changing Tables",
            "Nursery Gliders & Rocking Chairs", "Kids Table & Chair Sets",
            "Toy Storage", "Kids Bookcases & Shelving", "Play Tents & Tunnels"
        ]),

        ("Entryway", [
            "Entryway Benches", "Hall Trees", "Coat Racks", "Doormats"
        ]),

        ("Bathroom", [
            "Bathroom Vanities", "Bathroom Sinks", "Medicine Cabinets",
            "Bathroom Storage", "Towel Racks & Stands", "Shower Curtains & Liners",
            "Bathroom Rugs & Mats", "Laundry Hampers"
        ]),

        ("Lighting", [
            "Ceiling Lights", "Chandeliers", "Pendant Lights", "Flush Mount Lights",
            "Track Lighting", "Floor Lamps", "Table Lamps", "Desk Lamps",
            "Wall Sconces", "Night Lights", "String Lights", "Light Bulbs"
        ]),

        ("Rugs", [
            "Area Rugs", "Runners", "Doormats", "Outdoor Rugs",
            "Kitchen Mats", "Bathroom Rugs", "Kids Rugs", "Rug Pads"
        ]),

        ("Decor", [
            "Wall Art", "Paintings", "Prints", "Photography", "Wall Accents",
            "Mirrors", "Clocks", "Decorative Pillows", "Throw Blankets",
            "Candles & Holders", "Vases", "Decorative Bowls & Trays",
            "Sculptures & Figurines", "Picture Frames", "Plants & Flowers",
            "Window Treatments"
        ]),

        ("Home Improvement", [
            "Hardware (Knobs, Pulls)", "Wallpaper", "Wall Paneling",
            "Flooring (Tiles, Wood)", "Fireplaces & Accessories",
            "Fans (Ceiling, Portable)"
        ]),

        ("Commercial Furniture", [
            "Office Furniture Sets", "Reception Desks", "Conference Tables",
            "Office Partitions", "Restaurant Tables & Chairs", "Bar Furniture",
            "Hotel Furniture", "Retail Displays & Shelving"
        ]),

        ("Game Room", [
            "Pool Tables", "Foosball Tables", "Air Hockey Tables",
            "Poker Tables & Sets", "Game Tables", "Gaming Chairs",
            "Dartboards & Cabinets", "Bar & Pub Tables", "Home Theater Seating"
        ]),

        ("Bar Furniture", [
            "Home Bar Sets", "Bar Tables", "Pub Tables", "Bar Stools",
            "Bar Cabinets", "Wine Racks", "Wine Storage", "Bar Carts",
            "Liquor Cabinets"
        ]),

        ("Pet Furniture", [
            "Dog Beds", "Cat Trees & Condos", "Pet Crates & Kennels",
            "Pet Gates", "Feeding Stations", "Pet Steps & Ramps"
        ]),

        ("Accent Furniture", [
            "Accent Chairs", "Accent Tables", "Accent Cabinets & Chests",
            "Ottomans & Poufs", "Benches", "Room Dividers", "Étagères & Shelves",
            "Trunks"
        ]),

        ("Laundry & Utility", [
            "Utility Cabinets & Sinks", "Laundry Hampers", "Ironing Boards",
            "Drying Racks", "Folding Stations", "Step Stools", "Cleaning‑Supply Storage"
        ]),

        ("Home Fitness & Gym", [
            "Weight Benches & Racks", "Treadmill / Bike Stands", "Yoga & Mat Storage",
            "Multi‑Gym Stations", "Fitness Mirrors", "Gym Flooring Tiles"
        ]),

        ("Garage & Workshop", [
            "Workbenches", "Tool Cabinets & Chests", "Wall‑Mounted Storage",
            "Utility Shelving", "Pegboards", "Bike Racks"
        ]),

        ("Music & Studio", [
            "Studio Desks", "Speaker Stands", "Keyboard Stands",
            "Instrument Racks & Cabinets", "Recording Booth Panels", "Sheet‑Music Storage"
        ]),

        ("Medical & Accessibility", [
            "Lift Chairs", "Adjustable Beds", "Over‑Bed Tables",
            "Shower Seats", "Grab Bars", "Walker / Wheelchair Storage"
        ]),

        ("Event & Folding Furniture", [
            "Folding Tables", "Folding Chairs", "Stackable Chairs",
            "Portable Stages & Risers", "Table Carts", "Chair Dollies"
        ]),

        ("Seasonal & Holiday", [
            "Holiday Trees & Stands", "Decorative Figurines", "Seasonal Storage Bins",
            "Patio Heaters"
        ]),

        ("Classroom & Educational", [
            "Student Desks", "Classroom Chairs", "Activity Tables",
            "Storage Cubbies", "Library Carrels", "Teacher Desks"
        ])
    };
    
    // Brand definitions
    public static readonly Dictionary<string, double> BrandDistribution = new()
    {
        ["VanArsdel Home"] = 0.45,
        ["Contoso Furniture"] = 0.2,
        ["Northwind Traders"] = 0.20,
        ["Wide World Importers"] = 0.15,
    };
    
    
    // Material and price bands by top-level category
    public static readonly
        Dictionary<string, (string[] Materials, double[] Weights)> MaterialMap = new()
        {
            ["Living Room"] = (["Fabric", "Leather", "Wooden", "Metallic"], [0.45, 0.20, 0.25, 0.10]),
            ["Bedroom"] = (["Wooden", "Upholstered", "Metallic"], [0.60, 0.25, 0.15]),
            ["Mattresses & Bedding"] = (["Foam", "Latex", "Innerspring", "Hybrid"], [0.35, 0.20, 0.25, 0.20]),
            ["Dining Room"] = (["Wooden", "Glass", "Metallic", "Marble"], [0.55, 0.20, 0.15, 0.10]),
            ["Kitchen"] = (["Wooden", "Metallic", "Plastic", "Stone"], [0.40, 0.30, 0.15, 0.15]),
            ["Office"] = (["Wooden", "Metallic", "Laminate", "Glass"], [0.40, 0.35, 0.15, 0.10]),
            ["Storage & Organization"] = (["Wooden", "Metallic", "Plastic", "Fabric"], [0.45, 0.25, 0.20, 0.10]),
            ["Outdoor"] = (["Metallic", "Rattan", "Wooden", "Plastic"], [0.40, 0.25, 0.20, 0.15]),
            ["Baby & Kids"] = (["Wooden", "Plastic", "Fabric"], [0.50, 0.30, 0.20]),
            ["Entryway"] = (["Wooden", "Metallic", "Glass"], [0.60, 0.25, 0.15]),
            ["Bathroom"] = (["Wooden", "Metallic", "Plastic", "Glass"], [0.25, 0.30, 0.25, 0.20]),
            ["Lighting"] = (["Metallic", "Glass", "Wooden"], [0.45, 0.45, 0.10]),
            ["Rugs"] = (["Wool", "Synthetic", "Jute"], [0.45, 0.40, 0.15]),
            ["Decor"] = (["Wooden", "Glass", "Metallic", "Ceramic"], [0.25, 0.25, 0.25, 0.25]),
            ["Home Improvement"] = (["Metallic", "Wooden", "Composite", "Plastic"], [0.40, 0.30, 0.20, 0.10]),
            ["Commercial Furniture"] = (["Metallic", "Wooden", "Laminate", "Fabric"], [0.50, 0.30, 0.10, 0.10]),
            ["Game Room"] = (["Wooden", "Metallic", "Laminate", "Plastic"], [0.50, 0.25, 0.15, 0.10]),
            ["Bar Furniture"] = (["Wooden", "Metallic", "Leather"], [0.50, 0.30, 0.20]),
            ["Pet Furniture"] = (["Wooden", "Fabric", "Plastic"], [0.30, 0.40, 0.30]),
            ["Accent Furniture"] = (["Wooden", "Metallic", "Glass", "Marble"], [0.45, 0.25, 0.20, 0.10]),
            ["Laundry & Utility"] = (["Metallic", "Plastic", "Wooden"], [0.45, 0.40, 0.15]),
            ["Home Fitness & Gym"] = (["Metallic", "Rubber", "Wooden"], [0.60, 0.30, 0.10]),
            ["Garage & Workshop"] = (["Metallic", "Wooden", "Plastic"], [0.60, 0.25, 0.15]),
            ["Music & Studio"] = (["Wooden", "Metallic", "Foam"], [0.45, 0.30, 0.25]),
            ["Medical & Accessibility"] = (["Metallic", "Plastic", "Fabric"], [0.50, 0.30, 0.20]),
            ["Event & Folding Furniture"] = (["Metallic", "Plastic", "Wooden"], [0.50, 0.30, 0.20]),
            ["Seasonal & Holiday"] = (["Plastic", "Metallic", "Wooden"], [0.50, 0.30, 0.20]),
            ["Classroom & Educational"] = (["Wooden", "Metallic", "Laminate"], [0.40, 0.40, 0.20])
        };

    public static readonly Dictionary<string, (int min, int max)> StockLevelRanges = new()
    {
        ["Living Room"] = (100, 300),
        ["Bedroom"] = (80, 250),
        ["Mattresses & Bedding"] = (60, 200),
        ["Dining Room"] = (70, 220),
        ["Kitchen"] = (50, 150),
        ["Office"] = (40, 120),
        ["Storage & Organization"] = (100, 300),
        ["Outdoor"] = (60, 180),
        ["Baby & Kids"] = (40, 120),
        ["Entryway"] = (20, 70),
        ["Bathroom"] = (20, 70),
        ["Lighting"] = (40, 150),
        ["Rugs"] = (30, 100),
        ["Decor"] = (50, 200),
        ["Home Improvement"] = (20, 70),
        ["Commercial Furniture"] = (10, 40),
        ["Game Room"] = (20, 70),
        ["Bar Furniture"] = (20, 70),
        ["Pet Furniture"] = (20, 70),
        ["Accent Furniture"] = (40, 150),
        ["Laundry & Utility"] = (20, 70),
        ["Home Fitness & Gym"] = (10, 40),
        ["Garage & Workshop"] = (10, 40),
        ["Music & Studio"] = (10, 40),
        ["Medical & Accessibility"] = (10, 40),
        ["Event & Folding Furniture"] = (10, 40),
        ["Seasonal & Holiday"] = (10, 40),
        ["Classroom & Educational"] = (10, 40)
    };
}