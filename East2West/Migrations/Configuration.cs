namespace East2West.Migrations
{
    using East2West.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<East2West.Data.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //LOCAL_1 = LocationID
        //TOUR_1 = TouID
        //TOURDT_1 = TourDetailId
        //TOURSD_1 = TourScheduleId
        //CARBR_1 = CarBrandId
        //CARMD_1 = CarModelId
        //CARTP_1 = CarTypeId
        //CAR_1 = CarId
        //HT_1 = HotelId
        //FL_1 = FlightId
        protected override void Seed(East2West.Data.DBContext context)
        {
            //Địa điểm 
            context.Locations.AddOrUpdate(x => x.Id,
                new Location() { Id = "LOCAL_1", Name = "Ha Noi", Description = "Hanoi is a dreamy city that has infatuated the human heart." },
                new Location() { Id = "LOCAL_2", Name = "Bangkok", Description = "Bangkok, officially known in Thai as Krung Thep Maha Nakhon and colloquially as Krung Thep, is the capital and most populous city of Thailand." },
                new Location() { Id = "LOCAL_3", Name = "Kathmandu", Description = "Kathmandu, officially the Kathmandu Metropolitan City, is the capital and the most populous city of Nepal " },
                new Location() { Id = "LOCAL_4", Name = "Da Nang", Description = "Da Nang is a city directly under the central government, located in the South Central Coast region of Vietnam, is the central and largest city in the Central - Central Highlands region. " },
                new Location() { Id = "LOCAL_5", Name = "Phu Quoc", Description = "Phu Quoc is an island located in the Gulf of Thailand and is the largest island in Vietnam. Administratively, Phu Quoc island, together with neighboring smaller islands and Tho Chu archipelago, 55 nautical miles to the southwest, composes Phu Quoc island city under Kien Giang province. " },
                new Location() { Id = "LOCAL_6", Name = "Scotland", Description = "Scotland is a country in the United Kingdom of Great Britain and Northern Ireland. Scotland occupies the northern third of the island of Great Britain, is bordered by England to the south, the Atlantic Ocean surrounds the remaining sides: of which the North Sea is to the east, and the North Strait and the Irish Sea to the west -male." },
                new Location() { Id = "LOCAL_7", Name = "Phu Yen", Description = "Phu Yen is known as a wild and beautiful land with many beaches, lagoons, historical and cultural relics such as Nhan Mountain, Da Bia Mountain, Vung Ro, Bai Mon - Mui Dien, O Loan lagoon, Ganh Da Dia, Mang Lang Church, Xuan Dai Bay, Dong Cam Dam. In addition, Phu Yen has many other scenic spots such as Bai Xep, Vinh Hoa beach, Tu Nham sand hill, Nua island, Chua island, Nhat Tu Son island, Bau beach, Yen island, Ganh Den, Cay Du waterfall, H'Ly waterfall. , Van Hoa Plateau..." },
                new Location() { Id = "LOCAL_8", Name = "TURKEY", Description = "Turkey is a democratic, secular, unitary, and constitutional republic with a diverse cultural heritage." },
                new Location() { Id = "LOCAL_9", Name = "SRI LANKA", Description = "Sri Lanka, officially the Democratic Socialist Republic of Sri Lanka is an island nation with a majority Buddhist population in South Asia, located about 33 miles off the coast of the southern Indian state of Tamil Nadu. The country is often referred to as the 'Pearl of the Indian Ocean'." }
                );
            //Tour
            context.Tours.AddOrUpdate(x => x.Id,
                new Tour() { Id = "TOUR_1", DepartureId = "LOCAL_1", DestinationId = "LOCAL_3", Name = "Nagarkot Sunrise Tour", Description = "Behold a spectacular sunrise from Nagarkot Hilltop", Detail = "Enjoy the best view of the Kathmandu valley on this hike. Discover rural traditions and exceptional hiking routes and admire the striking mountains and rural landscapes.", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655638385/e2w/download_dfibfd.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655741011/e2w/c25c92fc-Nagarkot-Sunrise-Tour_ddhk9b.webp , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655741058/e2w/28c46a14-Nagarkot-Sunrise-Tour_rxpiey.webp , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655741084/e2w/357b7a05-Nagarkot-sunrise-5_slmcls.webp", Duration = 3, Rating = 5, Policy = "BOOKING ON BEHALF OF OTHERS: If you make a booking for anyone other than yourself, you are considered the designated contact person for those other travelers. You represent and warrant that you are legally authorized to act on their behalf; that you have obtained all required consents; and that you will inform them of these Terms and warrant that they accept and agree to them. You are also responsible for making all payments due for your booking; notifying us if any changes or cancellations are required; and keeping the other travelers informed of all information relevant to your trip. REGISTRATION: After you complete your booking, we'll send you an email containing a link to a secure traveler registration form. For most packages, you must complete this form within 5 days of booking. Let us know if you are unable to complete it within this timeframe, or your booking may be subject to cancellation. CONFIRMATION: After we receive your booking and deposit, we will confirm availability of all components and send you a confirmation email within 1–2 business days. If any option or component you selected is not available, we will alert you and give you the option to modify your booking or to cancel and receive a refund of your deposit.", SummarySchedule = "Ha Noi - Nepal - Nagarkot ", Status = 1, CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
                new Tour() { Id = "TOUR_2", DepartureId = "LOCAL_1", DestinationId = "LOCAL_4", Name = "Series | Ha Noi - Da Nang", Description = "SERIES | HANOI - DA NANG - BA NA - HOI AN", Detail = "Coming to Da Nang, visitors not only have the opportunity to visit the beautiful scenery of the sea but also have the opportunity to enjoy unforgettable special dishes, visit the charming natural scenery of the river and enjoy many famous specialties here. this. In addition, in the travel itinerary with Hanoitourist's Da Nang - Hoi An tour, you can also feel the peaceful beauty of Hoi An ancient town and the culinary beauty here.", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655794879/e2w/63451_mwh9h0.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655794883/e2w/63453_nq69ji.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655794886/e2w/63455_vsf0fm.png", Duration = 4, Rating = 5, Policy = "<p>Price includes:</p><p>Air tickets and airport fees Hanoi - Da Nang - Hanoi (Vietnam Airlines ticket includes 20kg of checked baggage).</p><p>Modern air-conditioned cars exclusively for the group (with hand sanitizer on board)</p><p>Sekong 3 *** hotel on the seafront (early check-in time from 14h00; check-out at 12h00): 02 adults/room - odd group of guests use room 3, children sleep with parents without standard private room )</p><p>Meals according to the program 120,000 VND / person / main meal * 06 main meals. Breakfast buffet at the hotel.</p><p>You can take care of the entrance tickets at the tourist attractions in the program.</p><p>You can buy travel insurance throughout the route with a maximum compensation of 120,000,000 VND/person.</p><p>Guests are served cold towels, mineral water in the car, the norm is 1 bottle / person / day, the limit is 1 mask / day / person.</p><p>Tour guide picks you up at the airport in Hanoi</p><p>Tour guide in Da Nang, enthusiastic experience, explain the route, serve the group according to the program.</p><p>Price does not include:</p><p>Cable car tickets &amp; games at Ba Na + Eating Ba Na resort: 850,000 VND/pax (fares may change at the time of using the service)</p><p>If going to Cu Lao Cham: 600,000 VND/pax</p><p>If going to Vinpearl Nam Hoi An: 700,000 VND/pax.</p><p>Single room sleep, drinks. Personal expenses other than the program.</p><p>Tipping for drivers and guides.</p><p>SUPPLY FOR SINGLE ROOM: 1,100,000 VND</p><p>Cancellation policy:</p><p>Note:</p><p><br></p><p>The order of attractions can be changed to match the actual program of the group, but still ensure the full range of attractions.</p><p>Flight time may change according to flight time of Vietnam Airlines.</p>", SummarySchedule = "HANOI - DA NANG - BA NA - HUE - HOI AN - HANOI", Status = 1, CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
                new Tour() { Id = "TOUR_3", DepartureId = "LOCAL_1", DestinationId = "LOCAL_5", Name = "EXPLORE PHU QUOC", Description = "SERIES | HANOI - PHU QUOC", Detail = "Explore Phu Quoc pearl island which is known as the island paradise of Vietnam in 3 days 2 nights.", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655799709/e2w/63543_h9i0wo.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655799719/e2w/63545_imuz24.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655799724/e2w/63547_ubullo.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655799733/e2w/63549_d8sfxk.png", Duration = 4, Rating = 5, Policy = "<p>Price includes:</p><p>Air tickets and airport fees Hanoi - Phu Quoc - Hanoi with BamBoo Airways: group tickets, non-refundable, non-cancellable, unchanged (including 07kg hand baggage, 20kg checked baggage)</p><p>New air-conditioned cars according to the schedule in Phu Quoc.</p><p>Airport pick-up and drop-off from Hanoi - Noi Bai and vice versa</p><p>Standard hotel rooms 3 *, 4 *, 5 * depending on your choice. 02 people/room, if odd men or women use room 03 people.</p><p>3* Hotel: Hotel Happy Phu Quoc 3* or equivalent</p><p>4* Hotel: Sonaga Resort 4* or equivalent</p><p>5* Hotel: Best Western Sonasea Phu Quoc 5* or equivalent</p><p>Meals according to the program: Main meals: 05 meals x 150,000 VND/person/meal, including 01 meal on board. Have breakfast at Hotel.</p><p>Fishing boat, coral viewing, fishing gear, bait, tools.</p><p>Enthusiastic, experienced tour guide welcomes you at Noi Bai airport and follows you throughout the journey in Phu Quoc.</p><p>Sightseeing fees for the first entry points in the program.</p><p>Travel insurance throughout the route (maximum compensation 120,000,000 VND/case).</p><p>Drinking water in the car 01 bottle/person/day.</p><p>Tax</p><p>Price does not include:</p><p>Expenses for swimming, entertainment and personal expenses.</p><p>Round trip ticket for Hon Thom cable car 540,000 VND (According to regulations of Sun Group).</p><p>Tickets for entrance fees at Grand World: Bear Museum 200,000 VND/person, Essence of Vietnam 200,000 VND/person, river cruise 200,000 VND/person. (According to Vin Group&apos;s regulations)</p><p>Personal expenses and other expenses incurred outside the program, sleeping in a single room, overtime travel, drinks, etc.</p><p>Tips for tour guide and driver</p><p>Cancellation policy:</p><p>If you cancel the tour after registration or before 15 days of departure: tour deposit fee will be forfeited</p><p>If you cancel the tour from 10 to 15 days before the departure date: cancellation fee of 70% of the tour value.</p><p>If you cancel the tour within 10 days before departure date: 100% cancellation fee of tour value.</p><p>&nbsp;</p><p><br></p><p>Note : Whichever condition comes first, we will apply that condition.</p>", SummarySchedule = "HANOI - DA NANG - BA NA - HUE - HOI AN - HANOI", Status = 1, CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
                new Tour() { Id = "TOUR_4", DepartureId = "LOCAL_1", DestinationId = "LOCAL_6", Name = "ENGLAND TOUR", Description = "ENGLAND & SCOTLAND TOUR - LAND OF MOT", Detail = "Price includes urgent visa service. Comfortable 4-star hotel, convenient to visit. Enjoy the taste of typical European dishes. Experienced and enthusiastic guides throughout the route. Visiting Big Ben Clock Tower, Buckingham Palace,.. Visit Bibury Ancient Village - The oldest village in England.", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802108/e2w/67488_iyg82d.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802112/e2w/67491_ttrya2.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802120/e2w/67494_wqnyfn.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802129/e2w/67552_zid7uq.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802136/e2w/67555_dvkhsi.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802143/e2w/67558_fbiorb.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802150/e2w/67561_cyxazm.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802155/e2w/67577_odfz6o.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802163/e2w/67564_kphogt.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802173/e2w/67596_gw4bol.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802180/e2w/67599_datxs3.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802188/e2w/67637_roskwn.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802199/e2w/67643_hsbkmk.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802204/e2w/67640_fjmq5i.png", Duration = 11, Rating = 5, Policy = "<p>Price includes:</p><p>Round trip airfare of Vietnamairlines</p><p>Airport fee + airline tax.</p><p>4* standard hotel</p><p>Meals according to the program are from 18 GPB - 20 GPB/meal.</p><p>Tickets to visit places according to the program. Admission to Stonehenge and Scotch Whiskey</p><p>Cars are transported according to the program (10 hours/day)</p><p>Vietnamese tour guide throughout the route from Vietnam</p><p>&nbsp; Fee for translating documents and procedures for UK visa (non-refundable cost 6,000,000 VND) &ndash; The current UK visa application period needs at least 12 weeks</p><p>MIC travel insurance coverage up to 50,000 USD/person/case</p><p>Gifts of Hanoi Tourist</p><p>VAT according to government regulations 0% service abroad and 8% domestic service</p><p>Price does not include:</p><p>Passport fee.</p><p>Tipping for tour guide and driver (about 7 GBP / 1 pax / 1 day tour).</p><p>Personal costs</p><p>Excess baggage</p><p>Excursions outside the program</p><p>Surcharge for single room stay (if any).</p><p>Extra tips for drivers and guides if the time limit is over.</p><p>Urgent visa fee (8,000,000 VND) (If any)</p><p>Cancellation policy:</p><p>Note:</p><p>For objective reasons, the program or route may change or the contents of the itinerary will be rearranged (but still ensuring the existing contents).</p><p>Visiting the cities listed in the program, in case you need services to get out of these cities to a place not listed in the program, you must satisfy agreement on increased costs.</p><p>Request you to comply with the scheduled time, if due to force majeure objective reasons (traffic jams...) or because of your own wishes with the consensus of all members of the team working on time. If there is a shortage of time for that day&apos;s itinerary, it is possible that the next destinations on that day will be skimmed or have to be omitted.</p><p>We are not responsible for refunding services in the program that you do not use.</p><p>We are not responsible for any delay on your part.</p><p>During the journey, you are not allowed to automatically receive more family members or acquaintances on the bus without a service agreement with us in advance.</p><p>Flight and flight time, airline, flight date may change depending on the visa issuance schedule of the embassy. Vehicles transported in England - Scotland will travel no more than 10 hours/day.</p>", SummarySchedule = "LONDON - AMSBURY - BATH - BRITOL - STRAFFORD - UPON - AVON - MANCHESTER - EDINBURGH - YORK - OXFORD - BIBURY - LONDON", Status = 1, CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
                new Tour() { Id = "TOUR_5", DepartureId = "LOCAL_1", DestinationId = "LOCAL_7", Name = "SERIES | TOURISM TUY HOA", Description = "Phu Yen is developing strongly and is becoming an interesting stop on the tourist map of Vietnam.", Detail = "Conquer Phuong Mai sand dune - the place is known as - A desert in the heart of the blue sea. Sightseeing: Da Dia Ghenh, O Loan lagoon, Mang Lang Church - An ancient French architecture. Twin Towers - a cluster of towers with 02 ancient towers with Angkorian architecture, built in the 12th century. - Cathedral Church. Visit Ghenh Rang Tourist Area with Thi Nhan Hill, Mong Cam Doc, Visit Tomb of poet Han Mac Tu, Fire Pen Dzu Kha,...", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811416/e2w/119178_fqnlmn.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811302/e2w/74272_vrooht.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811305/e2w/74275_ilyihw.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811312/e2w/74278_ogpcbm.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811318/e2w/74281_jqre1y.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811323/e2w/74284_penfq1.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811334/e2w/74287_cg1s4a.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811342/e2w/74290_yl6cfe.png", Duration = 4, Rating = 4.5, Policy = "<p>Price includes:</p><p>Round-trip flight ticket Hanoi - Quy Nhon - Hanoi (Non-refundable, non-cancellation, change) of Vietnamairlines: including 10kg hand luggage and 1 piece of 23kg checked baggage</p><p>Private transportation service according to the program</p><p>3-star standard hotel according to the program (Flora, Rustic, Yen Vy 4 hotels or equivalent): 02 people/room, if odd, triple room. Children under 12 years old sleep with parents, no standard room.</p><p>Meals according to the program: Breakfast at the hotel. Standard meal 130,000 VND/person/meal x 06 meals.</p><p>Tickets to visit 1 time at the attractions according to the program.</p><p>Experienced tour guide, enthusiastic service according to the program in Quy Nhon &amp; Tuy Hoa</p><p>Guide to pick up &amp; drop off the airport in Hanoi</p><p>Drinking water: 01 bottle of mineral water 500ml/person/day in the car</p><p>Travel hat gift</p><p>Travel insurance pays up to 120,000,000 VND/person/case (depending on each incident)</p><p>VAT invoice as prescribed</p><p>Price does not include:</p><p>Drinks and personal expenses are not included in the program</p><p>Cost of single room (if any)</p><p>Ky Co tour cost (including 1 seafood lunch): 420,000vnd/adult</p><p>Tipping for guides and drivers.</p><p>Cancellation policy:</p><p>Conditions of tour cancellation:</p><p>If you cancel the tour after registration and 30 days before departure: tour deposit fee will be forfeited</p><p>If you cancel the tour from 15-30 days before departure date: 50% cancellation fee of tour value.</p><p>If you cancel the tour from 07-15 days before departure date: 70% cancellation fee of tour value.</p><p>If you cancel the tour within 07 days before departure date: 100% cancellation fee of tour value.</p><p>(Note: Whichever comes first we will apply.)</p><p><br></p><p>Conditions for air tickets:</p><p>Flight time is subject to change according to the airline&apos;s flight time.</p><p>When traveling by plane, you should bring one of the following documents: (valid ID card, ID card, or passport with more than 6 months validity,... birth certificate (for children under 6 months old) 14 years old).</p><p>If you cancel the tour due to being refused to check in at the airport due to identity / identification The travel agency is not responsible for the above incident. Program costs will not be refunded in this case.</p><p>Conditions of safe reception:</p><p>Comply with the &ldquo;5K Message&rdquo;</p><p>Medical declaration according to regulations</p><p>Comply with Hanoitourist&apos;s epidemic prevention and control instructions.</p><p>General regulations:</p><p>Due to the nature of the group, if the group has 10 adults or more, the group will depart on the same day. If the group does not have enough 10 guests, Party B will arrange a new departure date and notify Party A 15 days in advance.</p><p>If Party B does not organize for the delegation to go at the scheduled time due to force majeure causes such as natural disasters, storms, floods, war.... Party B will arrange a new departure date, all costs incurred shall be agreed upon by both parties.</p><p>Price from</p><p><br></p><p>VND 6,290,000</p><p><br></p><p>KEEP ONLY</p><p><br></p><p>REGISTER FOR CONSULTATIONS</p><p><br></p><p>Hotline: 19004518</p><p><br></p><p>Tags: Quy Nhon travel experience, Quy Nhon tourism, Discover Quy Nhon</p><p>ALL QUESTIONS PLEASE CONTACT US</p><p>Phone</p><p>Hotline:</p><p>19004518</p><p>Mail</p><p>Email:</p><p>sales@hanoitourist.vn</p><p>OR LEARN INFORMATION</p><p>First and last name</p><p>Enter your first and last name</p><p>Email or Phone Number</p><p>Enter your email or phone number</p>", SummarySchedule = "HANOI - QUY NHON - TUY HOA - HANOI", Status = 1, CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
                new Tour() { Id = "TOUR_6", 
                    DepartureId = "LOCAL_1",
                    DestinationId = "LOCAL_8",
                    Name = "TOUR TURKEY",
                    Description = "Heritage journey 8 days 7 nights to discover Turkey - the country is known as 'Crossroads of civilizations'.",
                    Detail = "Stay 2 nights in a 4-star hotel in Cappadocia and 2 nights in Istanbul full of the most unique attractions.Experience the sunrise on a hot air balloon in the rock city of Cappadocia.Admire countless mysterious ancient monuments in Istanbul, Kudasadi, Pamukale with typical examples being the world wonder of the ancient citadel of Ephesus, the ancient wonder of the Temple of Atemis, etc. Natural wonder 'Cotton Castle' Pamukale.Cruise on the Bosphorus Strait connecting the 2 continents of Eurasia.Experience mud bath, fish massage.Free 1 belly dance dinner + free flow drink in Cappadocia", 
                    Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656339364/e2w/67714_mdlxf7.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656339370/e2w/67772_zo3ptf.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656339376/e2w/67775_lj0s9y.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656339395/e2w/67790_odx5r0.png ", 
                    Duration = 8    , 
                    Rating = 4.5, 
                    Policy = "Stay 2 nights in a 4-star hotel in Cappadocia and 2 nights in Istanbul full of the most unique attractions.Experience the sunrise on a hot air balloon in the rock city of Cappadocia.Admire countless mysterious ancient monuments in Istanbul, Kudasadi, Pamukale with typical examples being the world wonder of the ancient citadel of Ephesus, the ancient wonder of the Temple of Atemis, etc. Natural wonder 'Cotton Castle' Pamukale.Cruise on the Bosphorus Strait connecting the 2 continents of Eurasia.Experience mud bath, fish massage.Free 1 belly dance dinner + free flow drink in Cappadocia", 
                    SummarySchedule = "HA NOI - ISTABUL - IZMIR - KUSADASI - PAMUKALE - KONYA - CAPPADOCIA - ISTANBUL - HA NOI", 
                    Status = 1, 
                    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"), 
                    UpdatedAt = DateTime.Now, 
                    DeletedAt = DateTime.Now },
                new Tour()
                {
                    Id = "TOUR_7",
                    DepartureId = "LOCAL_1",
                    DestinationId = "LOCAL_9",
                    Name = "DISCOVER THE INDIAN PEARL SRI LANKA",
                    Description = "Of the eight sites of Sri Lanka recognized by UNESCO as a world heritage site, there are five sites with temples built more than 2,000 years ago that still retain their ancient architectural and appearance. .",
                    Detail = "Welcome to Sri Lanka and make the most of this opportunity to visit the best places of interest in this magnificent Island. As you step into an Island with enchanting atmosphere and a breathtaking nature we offer you tour choices covering a great variety of remarkable and outstanding places that gets your tour interesting by the minute. Beach lovers can finally explore the finest tropical sandy beaches, experience jungle trekking and wild life safaris, visit ancient places with historical values and learn more about how Sri Lankan ancestors lived back then and the unmatched beauty in hill country.",
                    Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656417081/e2w/184991_brd2gm.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656417049/e2w/184974_vrgfmk.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656417061/e2w/184978_fpbmqh.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656417074/e2w/184987_y8w5uw.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656417088/e2w/184995_melcmd.jpg",
                    Duration = 6,
                    Rating = 4,
                    Policy = "<p>Price includes:</p><p>Car pick up and drop off Noi Bai airport.</p><p>Round-trip airfare Hanoi // TP. HCM - Colombo - Hanoi // City. Ho Chi Minh City of Singapore Airlines, natural goods and domestic air tax (7 kg hand baggage, 25 kg checked baggage)</p><p>Car transportation to visit according to the program.</p><p>Visa to enter Sri Lanka.</p><p>04 4 * hotels, 2 guests / room, odd guests sharing rooms of the same sex (odd male pairing male / odd female pairing female)</p><p>Meals and dinners at local restaurants.</p><p>01 dimensional PCR check for each customer</p><p>Entrance key to the entrance (1st time) according to the program</p><p>Local support guides during the tour in Sri Lanka and professional and enthusiastic online Vietnamese guides Travel insurance with maximum value (Medical or unexpected incident: 1 Billion VND. 400 million accidents)</p><p>Confidential Covid-19 - 30 days in hospital according to Sri Lankan regulations</p><p>Hanoitourist Hat + 01 bottle of mineral water / person / day</p><p>Price does not include:</p><p>&nbsp; &nbsp; &nbsp;Tip for driver and guide: 30 USD/pax.</p><p>The cost of PCR testing in Vietnam on the exit server.</p><p>Personal expenses not included in the program</p><p>Admission tickets at attractions outside the program</p><p>Separate room costs (if any)</p><p>For overseas Vietnamese who have a one-time visa to Vietnam, they must apply for a border gate visa to re-enter Vietnam (please contact for advice).</p><p>Roleprouctures:</p><p>Note:</p><p>1. The above prices apply to large customers, not during holidays, Tet or peak seasons.</p><p><br></p><p>2. If you are a vegetarian, please bring more vegetarian food to secure your place.</p><p><br></p><p>3. Visa key is not completed whether visa has been issued or not.</p><p><br></p><p>4. The program schedule can be changed to match the flight schedule and the local restaurant naturally ensures that enough reference points are updated in the program.</p><p><br></p><p>5. Visa application file:</p><p><br></p><p>02 new photos of 3.5 x 4.5 cm, clear, white background.</p><p>Original projection is limited to more than 6 months, submitted 15-20 days before launch.</p><p>Proving work and finance (if any)</p><p>Officially the program has been confirmed 1-2 days before the launch date. The schedule can change properties to weather, information interface but still ensure the full range of attractions.</p>",
                    SummarySchedule = "HA NOI - SRI LANKA - HA NOI",
                    Status = 1,
                    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
                    UpdatedAt = DateTime.Now,
                    DeletedAt = DateTime.Now
                }
               // new Tour()
               // {
               //     Id = "TOUR_8",
               //     DepartureId = "",
               //     DestinationId = "",
               //     Name = "",
               //     Description = "",
               //     Detail = "",
               //     Thumbnail = "",
               //     Duration = 4,
               //     Rating = 4.5,
               //     Policy = "",
               //     SummarySchedule = "",
               //     Status = 1,
               //     CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
               //     UpdatedAt = DateTime.Now,
               //     DeletedAt = DateTime.Now
               // },
               //new Tour()
               //{
               //    Id = "TOUR_9",
               //    DepartureId = "",
               //    DestinationId = "",
               //    Name = "",
               //    Description = "",
               //    Detail = "",
               //    Thumbnail = "",
               //    Duration = 4,
               //    Rating = 4.5,
               //    Policy = "",
               //    SummarySchedule = "",
               //    Status = 1,
               //    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
               //    UpdatedAt = DateTime.Now,
               //    DeletedAt = DateTime.Now
               //},
               //new Tour()
               //{
               //    Id = "TOUR_10",
               //    DepartureId = "",
               //    DestinationId = "",
               //    Name = "",
               //    Description = "",
               //    Detail = "",
               //    Thumbnail = "",
               //    Duration = 4,
               //    Rating = 4.5,
               //    Policy = "",
               //    SummarySchedule = "",
               //    Status = 1,
               //    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
               //    UpdatedAt = DateTime.Now,
               //    DeletedAt = DateTime.Now
               //},
               //new Tour()
               //{
               //    Id = "TOUR_11",
               //    DepartureId = "",
               //    DestinationId = "",
               //    Name = "",
               //    Description = "",
               //    Detail = "",
               //    Thumbnail = "",
               //    Duration = 4,
               //    Rating = 4.5,
               //    Policy = "",
               //    SummarySchedule = "",
               //    Status = 1,
               //    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
               //    UpdatedAt = DateTime.Now,
               //    DeletedAt = DateTime.Now
               //},
               //new Tour()
               //{
               //    Id = "TOUR_12",
               //    DepartureId = "",
               //    DestinationId = "",
               //    Name = "",
               //    Description = "",
               //    Detail = "",
               //    Thumbnail = "",
               //    Duration = 4,
               //    Rating = 4.5,
               //    Policy = "",
               //    SummarySchedule = "",
               //    Status = 1,
               //    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
               //    UpdatedAt = DateTime.Now,
               //    DeletedAt = DateTime.Now
               //},
               //new Tour()
               //{
               //    Id = "TOUR_13",
               //    DepartureId = "",
               //    DestinationId = "",
               //    Name = "",
               //    Description = "",
               //    Detail = "",
               //    Thumbnail = "",
               //    Duration = 4,
               //    Rating = 4.5,
               //    Policy = "",
               //    SummarySchedule = "",
               //    Status = 1,
               //    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
               //    UpdatedAt = DateTime.Now,
               //    DeletedAt = DateTime.Now
               //},
               //new Tour()
               //{
               //    Id = "TOUR_14",
               //    DepartureId = "",
               //    DestinationId = "",
               //    Name = "",
               //    Description = "",
               //    Detail = "",
               //    Thumbnail = "",
               //    Duration = 4,
               //    Rating = 4.5,
               //    Policy = "",
               //    SummarySchedule = "",
               //    Status = 1,
               //    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
               //    UpdatedAt = DateTime.Now,
               //    DeletedAt = DateTime.Now
               //},
               //new Tour()
               //{
               //    Id = "TOUR_15",
               //    DepartureId = "",
               //    DestinationId = "",
               //    Name = "",
               //    Description = "",
               //    Detail = "",
               //    Thumbnail = "",
               //    Duration = 4,
               //    Rating = 4.5,
               //    Policy = "",
               //    SummarySchedule = "",
               //    Status = 1,
               //    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
               //    UpdatedAt = DateTime.Now,
               //    DeletedAt = DateTime.Now
               //}
               );
               
            //Chi tiết của tour
            context.TourDetails.AddOrUpdate(x => x.Id,
               new TourDetail() { 
                   Id = "TOURDT_1", 
                   TourId = "TOUR_1", 
                   DepartureDay = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), 
                   AvailableSeat = 2, 
                   Price = 42.5, 
                   Discount = 15, 
                   CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), 
                   UpdatedAt = DateTime.Now, 
                   DeletedAt = DateTime.Now 
               },
               new TourDetail() { Id = "TOURDT_2", TourId = "TOUR_2", DepartureDay = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), AvailableSeat = 20, Price = 193, Discount = 10, CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
               new TourDetail() { Id = "TOURDT_3", TourId = "TOUR_3", DepartureDay = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), AvailableSeat = 25, Price = 266, Discount = 10, CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
               new TourDetail() { Id = "TOURDT_4", TourId = "TOUR_4", DepartureDay = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), AvailableSeat = 25, Price = 3525, Discount = 10, CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
               new TourDetail() { Id = "TOURDT_5", TourId = "TOUR_5", DepartureDay = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), AvailableSeat = 25, Price = 270, Discount = 10, CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
               new TourDetail() { Id = "TOURDT_6", TourId = "TOUR_6", DepartureDay = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), AvailableSeat = 25, Price = 1543, Discount = 10, CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
               new TourDetail()
               {
                   Id = "TOURDT_7",
                   TourId = "TOUR_7",
                   DepartureDay = Convert.ToDateTime("2022-08-09T23:49:58+02:00"),
                   AvailableSeat = 30,
                   Price = 1200,
                   Discount = 15,
                   CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00"),
                   UpdatedAt = DateTime.Now,
                   DeletedAt = DateTime.Now
               }
               );
            //Lịch trình của tour
            context.TourSchedules.AddOrUpdate(x => x.Id,
                 new TourSchedule() { Id = "TOURSD_1", TourId = "TOUR_1", ScheduleOrder = 1, Name = "Day 1", Detail = "Check in hotel" },
                 new TourSchedule() { Id = "TOURSD_2", TourId = "TOUR_1", ScheduleOrder = 2, Name = "Day 2", Detail = "Explore tourist attractions in Nagarkot" },
                 new TourSchedule() { Id = "TOURSD_3", TourId = "TOUR_1", ScheduleOrder = 3, Name = "Day 3", Detail = "Check out and go home" },
                 new TourSchedule() { Id = "TOURSD_4", TourId = "TOUR_2", ScheduleOrder = 1, Name = "Day 1", Detail = "<p>Morning: The company&apos;s car and tour guide pick you up at the meeting point and transfer you to Noi Bai airport for Vietjet flight VJ505 to Da Nang at 07:55.</p><p><br></p><p>Arriving at Da Nang airport, the car picks up the delegation and departs for you to depart for Non Nuoc Ngu Hanh Son</p><p><br></p><p>Lunch at the restaurant. After that, the group returned to the hotel to check in and rest.</p><p><br></p><p>Afternoon: You depart to visit Son Tra Peninsula (Monkey Mountain) to enjoy the panoramic view of Da Nang coastal city from above, along the Southeast mountainside to admire the beautiful beauty of Da Nang beach, visit Linh Ung Tu - the place with the highest 65m Buddha statue in Vietnam.</p><p><br></p><p>&nbsp;You are free to swim in Da Nang beach.</p><p><br></p><p>Evening: Have dinner at the restaurant, you are free to experience the feeling of Sun Wheel - Top 10 highest wheels in the world, admire the beauty of Da Thanh at night (expenses excluded)</p><p><br></p><p>Overnight at beach hotel</p>" },
                 new TourSchedule() { Id = "TOURSD_5", TourId = "TOUR_2", ScheduleOrder = 2, Name = "Day 2", Detail = "<p><strong>06h30</strong> Ăn s&aacute;ng tại kh&aacute;ch sạn.</p><p><strong>Lựa chọn 1</strong>: (V&eacute; c&aacute;p treo B&agrave; N&agrave; + ăn buffet B&agrave; N&agrave; 970.000 đồng/người &ndash; chi ph&iacute; tự t&uacute;c)<br><strong>Lưu &yacute;: Từ 18/3 &ndash; 24/4, KDL B&agrave; N&agrave; triển khai chương tr&igrave;nh khuyến mại mua v&eacute; c&aacute;p treo tặng v&eacute; buffet trưa.</strong></p><p><strong>07h30</strong> Đo&agrave;n&nbsp;khởi h&agrave;nh đi Khu du lịch B&agrave; N&agrave; - nơi c&oacute; thể kh&aacute;m ph&aacute; những khoảnh khắc giao m&ugrave;a bất ngờ trong một ng&agrave;y. Qu&yacute; kh&aacute;ch tham quan:&nbsp;</p><ul> <li><strong>Đi c&aacute;p treo đạt 2 kỷ lục của th&ecirc;́ giới</strong> - c&aacute;p treo một d&acirc;y d&agrave;i nhất (g&acirc;̀n 6000m) v&agrave; c&oacute; độ cao ch&ecirc;nh lệch giữa ga đi v&agrave; ga đến lớn nhất.&nbsp;</li> <li>Tham quan<strong>&nbsp;khu Le Jardin</strong><strong>&nbsp;</strong>với c&aacute;c di t&iacute;ch của người Ph&aacute;p như:&nbsp;khu buộc ngựa của Ph&aacute;p, c&acirc;y bưởi gần 100 tuổi, vết t&iacute;ch c&aacute;c khu biệt thự cổ.</li> <li>Vi&ecirc;́ng&nbsp;<strong>ch&ugrave;a Linh Ứng</strong> với tượng Phật Th&iacute;ch Ca cao 27m, tham quan Vườn Lộc Uyển, Quan &Acirc;m C&aacute;c.</li> <li>Chinh phục&nbsp;<strong>đỉnh n&uacute;i Ch&uacute;a</strong> ở độ cao 1.487m so với mực nước biển ngắm to&agrave;n cảnh Đ&agrave; Nẵng tr&ecirc;n cao.</li> <li>Tham gia vào các trò chơi tại&nbsp;<strong>Fantasy Park</strong> với&nbsp;c&aacute;c tr&ograve; chơi phi&ecirc;u lưu mới lạ, ngộ nghĩnh, hấp dẫn, hiện đại như v&ograve;ng quay t&igrave;nh y&ecirc;u, Phi c&ocirc;ng Skiver, Đường đua lửa, Xe điện đụng Ng&ocirc;i nh&agrave; ma... &nbsp;</li> <li>Ăn trưa buffet tại nh&agrave; h&agrave;ng</li></ul><p><strong>15h00</strong> Trở về ch&acirc;n n&uacute;i, xe đưa đo&agrave;n trở v&ecirc;̀ nghỉ ngơi và tắm bi&ecirc;̉n.</p><p><strong>Lựa chọn 2</strong>: Qu&yacute; kh&aacute;ch kh&ocirc;ng chọn lựa chọn 1</p><p>Qu&yacute; kh&aacute;ch tự do tắm biển, tham quan th&agrave;nh phố Đ&agrave; Nẵng, tự t&uacute;c ăn trưa</p><p>Ăn tối tại nh&agrave; h&agrave;ng. Buổi tối qu&yacute; kh&aacute;ch tự do kh&aacute;m ph&aacute; th&agrave;nh phố biển về đ&ecirc;m.</p><p>Nghỉ đ&ecirc;m tại kh&aacute;ch sạn mặt biển. &nbsp;</p>" },
                 new TourSchedule() { Id = "TOURSD_6", TourId = "TOUR_2", ScheduleOrder = 3, Name = "Day 3", Detail = "<div> <p>Ăn s&aacute;ng tại kh&aacute;ch sạn.</p> <p>Qu&yacute; kh&aacute;ch tự do tắm biển Mỹ Kh&ecirc;.</p> <p><strong>11h30</strong> Ăn trưa tại nh&agrave; h&agrave;ng.</p></div><div> <p><strong>Lựa chọn 1: (</strong> Nếu Qu&yacute; kh&aacute;ch đi Vinpearl Nam Hội An + 700.000 đồng/người)</p> <p><strong>14h00</strong>:&nbsp;Xe v&agrave; hướng dẫn đ&oacute;n đo&agrave;n khởi h&agrave;nh đi Khu du lịch Vinpearl Land Nam Hội An để Qu&yacute; kh&aacute;ch c&oacute; cơ hội kh&aacute;m ph&aacute; v&agrave; trải nghiệm Vinpearl River Safari, Vinpearl Land với 20 tr&ograve; chơi cảm gi&aacute;c mạnh ấn tượng, c&ocirc;ng vi&ecirc;n nước ho&agrave;nh tr&aacute;ng, khu vui chơi trong nh&agrave; gồm 95 tr&ograve; chơi điện tử, ph&ograve;ng chiếu phim 5D, khu vườn cổ t&iacute;ch&hellip;</p> <p><strong>Lựa chọn 2</strong>: Nếu qu&yacute; kh&aacute;ch kh&ocirc;ng đi Vinpearl Nam Hội An th&igrave; tự do tham quan.</p> <p><strong>17h30</strong> Xe đưa đo&agrave;n đi thăm&nbsp;khu phố cổ Hội An&nbsp;- được UNESCO c&ocirc;ng nhận l&agrave; di sản văn ho&aacute; thế giới v&agrave;o th&aacute;ng 12/1999: bảo t&agrave;ng lịch sử Hội An v&agrave; miếu Quan C&ocirc;ng, hội qu&aacute;n Phước Kiến, nh&agrave; cổ Tấn K&yacute;, ch&ugrave;a cầu Nhật Bản ăn tối tại Hội an tự do kh&aacute;m ph&aacute; phố cổ về đ&ecirc;m.</p> <p><strong>19h30</strong>:&nbsp;Đo&agrave;n ăn tối tại nh&agrave; h&agrave;ng.</p></div><p><strong>20h30 - 21h00</strong>: Đo&agrave;n tập trung l&ecirc;n xe v&agrave; hướng dẫn đưa đo&agrave;n khởi h&agrave;nh về Đ&agrave; Nẵng</p><p>Nghỉ đ&ecirc;m tại kh&aacute;ch sạn mặt biển.</p>" },
                 new TourSchedule() { Id = "TOURSD_7", TourId = "TOUR_2", ScheduleOrder = 4, Name = "Day 4", Detail = "<div> <p>Ăn s&aacute;ng tại kh&aacute;ch sạn.&nbsp;</p> <p>Xe đưa qu&yacute; kh&aacute;ch đi tham quan<strong>&nbsp;C&ocirc;ng vi&ecirc;n Kỳ Quan</strong> nằm tại ch&acirc;n cầu Thuận Phước, c&ocirc;ng tr&igrave;nh n&agrave;y bao gồm 9 kỳ quan nổi tiếng của thế giới v&agrave; c&aacute;c c&ocirc;ng tr&igrave;nh nổi tiếng của Việt Nam được m&ocirc; phỏng thu nhỏ như: Th&aacute;p Eiffel, Vạn L&yacute; Trường Th&agrave;nh, Tượng Nữ thần Tự do, Ch&ugrave;a Một Cột,....</p> <p><strong>Trưa:</strong> Đo&agrave;n ăn trưa tại nh&agrave; h&agrave;ng, l&agrave;m thủ tục trả ph&ograve;ng kh&aacute;ch sạn</p> <p><strong>Chiều:</strong> Đo&agrave;n tự do tham quan th&agrave;nh phố, mua đặc sản Đ&agrave; Nẵng về l&agrave;m qu&agrave;, sau đ&oacute; ra s&acirc;n bay đ&aacute;p chuyến bay<strong>&nbsp;VJ514</strong> l&uacute;c&nbsp;<strong>19h15</strong> khởi h&agrave;nh về H&agrave; Nội.</p> <p>Về đến s&acirc;n bay Nội B&agrave;i, xe đ&oacute;n qu&yacute; kh&aacute;ch về điểm hẹn ban đầu, chia tay qu&yacute; kh&aacute;ch. Kết th&uacute;c chương tr&igrave;nh.</p></div>" },
                 new TourSchedule() { Id = "TOURSD_8", TourId = "TOUR_3", ScheduleOrder = 1, Name = "Day 1", Detail = "<p>08h00: You are present at Thong Nhat Park, Tran Nhan Tong street, take to Noi Bai airport to check in for you to take flight QH1623 at 10:25 - 12:40 (on the plane with snacks), to Phu Quoc by car and guide to take the group to eat Bun Quat Kien Xay one of Phu Quoc specialties, then return to the hotel to check in and rest.</p><p><br></p><p>15h30: You go to visit:</p><p><br></p><p>Check-in at Vinwonder to take beautiful photos at the campus outside Vinwonder.</p><p><br></p><p>Check-in at Grand World Phu Quoc, an extremely high-class entertainment, entertainment and shopping complex belonging to Phu Quoc United Center, (You are free to have fun, explore and watch special shows - Expenses are not included in the price). including)</p><p><br></p><p>Unique Bamboo house architecture</p><p>Vietnam Essence Show</p><p>Cruise along the Venice River (Italy)</p><p>Shanghai Lantern District (China)</p><p>Unique color changing light dome in Clarke Quay style (Singapore)</p><p>Visiting Love Park</p><p>In addition, Teddy Bear Museum, Urban Park contemporary art park, Dating tower</p><p>Evening: Have dinner at your own expense and play at Grand World Phu Quoc.</p><p><br></p><p>21h00 - 21h30 car pick you up and take you to the hotel to check in and rest.</p>" },
                 new TourSchedule() { Id = "TOURSD_9", TourId = "TOUR_3", ScheduleOrder = 2, Name = "Day 2", Detail = "<p>You wake up early to watch the sunrise over the sea, have breakfast at the hotel. You depart to visit:</p><p><br></p><p>Phu Quoc Sea Pearl Farm:</p><p><br></p><p>You go to the 2nd town of Pearl Island, do procedures to board the boat, the ship takes the group out to sea to see beautiful islands like a miniature Ha Long Bay, the boat anchors for visitors to show off their fishing skills. (The catch will be processed by the ship&apos;s staff for visitors at the group&apos;s lunch). The ship anchors to an island with many corals for tourists to swim and snorkel to see the colorful world of coral reefs.</p><p><br></p><p>You have lunch on board with fresh seafood dishes that are processed in the wild but bold in the flavor of the people of the West Coast, and the spoils that you have caught after your interesting experience.</p><p><br></p><p>Afternoon: The boat takes the group back to the shore, you continue to visit:</p><p><br></p><p>Bai Sao Tourist Area, one of the most beautiful beaches on the island with fine white sand and clear blue sea.</p><p>You visit Phu Quoc Prison Historic Site</p><p>Visit Phu Quoc&apos;s traditional Fish Sauce Barrel house</p><p>Watch the sunset Sunset Sunato (own expense)</p><p>17h00 - 18h00 Delegation to the hotel to rest, free to visit and swim in the swimming pool at the hotel.</p><p><br></p><p>Dinner at the restaurant.</p><p><br></p><p>Evening: You are free to explore Phu Quoc night market or go squid fishing at night (own expense).</p><p><br></p><p>Overnight at the hotel.</p>" },
                 new TourSchedule() { Id = "TOURSD_10", TourId = "TOUR_3", ScheduleOrder = 3, Name = "Day 3", Detail = "<p>You wake up early to watch the sunrise over the sea. Eat breakfast at restaurant.</p><p><br></p><p>Option 1: You are free to rest, swim or visit relatives, free to have lunch.</p><p><br></p><p>Option 2: You go to visit 4 islands cost 650,000 VND/person. If you go 1 way by cable car, 1,100,000 VND/person. (price includes lunch).</p><p><br></p><p>8:00 - 8:30: Car &amp; guide pick you up at your hotel or rendezvous, depart for An Thoi port:</p><p>10:00 a.m. to An Thoi Cano port, you will take the delegation to Hon Roi area - Coral Park - where there is a form of walking on the ocean floor, (Seawalker) one of 3 rare coral parks in Vietnam, you can can experience the service of walking on the seabed (outside the program, at your own expense)</p><p>The delegation continued to get on a canoe to cross the islands, listen to explanations about 12 beautiful islands of Phu Quoc island district, prepare tools for fishing in the East Sea.</p><p>After exploring the ocean freely, the group continues the journey to Mong Tay Island - a hidden gem in the south of Phu Quoc Island, one of the islands possessing fine white sand with beautiful clear blue water. Group rest, swim, relax</p><p>Cano take the delegation to Gam Ghi Island (Dam Ngang) - the island is known as the Coral Kingdom - You dive to see the coral with the tools prepared: Snorkel, diving goggles, life jacket. The water is very shallow and in the slot, looking to the bottom, this is an ideal coral viewing spot. The large island with the rock &quot;Lion Head&quot;, the water is only 1 to 4 meters deep, which is very suitable for diving to see the corals. You will dive to see the coral here. I don&apos;t know how to swim or I&apos;m nearsighted and it works very well. HDV will support you if you do not know how to swim</p><p>Cano take the group to May Rut Island (Inside or outside) - You can admire the wild natural scenery, enjoy the beautiful sunset on the sea.</p><p>Lunch on the island.</p><p><br></p><p>14h00 - 14h30: Cano bring you back to shore, Car pick you up back to the hotel to rest and swim</p><p><br></p><p>Dinner at restaurant. Evening free to explore the coastal city at night.</p><p><br></p><p>Overnight at the hotel.</p>" },
                 new TourSchedule() { Id = "TOURSD_11", TourId = "TOUR_3", ScheduleOrder = 4, Name = "Day 4", Detail = "<p>You wake up early to watch the sunrise over the sea. Eat breakfast at restaurant.</p><p><br></p><p>Phu Quoc Pepper Specialty</p><p>Visit Sim garden Sim wine processing facility</p><p>Visiting Khanh Map dry specialty processing facility</p><p>10h40 Check out hotel, car take you to the airport to check in for you to take flight QH1624 at 13:15 - 15:30 (on the plane with snacks) to Noi Bai, car and tour guide pick you up and return to the original pick up point. . Good bye and see you again.</p>" },
                 new TourSchedule() { Id = "TOURSD_12", TourId = "TOUR_4", ScheduleOrder = 1, Name = "Day 1", Detail = "<p>21:00: Car and tour guide pick you up at the meeting point to Noi Bai airport for flight VN55 (00:05 - 07:40) to London. You stay on the plane.</p>" },
                 new TourSchedule() { Id = "TOURSD_13", TourId = "TOUR_4", ScheduleOrder = 2, Name = "Day 2", Detail = "<p>07h40 Arrive in London, Car and guide will pick you up at Heathrow Airport and take you to the city center. Dinner at the restaurant. You check in hotel to rest. Coming to the city of London, you cannot ignore the ancient and luxurious scenic spots here. The car and tour guide will take you to visit the following places:</p><p><br></p><p>Palace of Westminster (Outside): also called the Houses of Parliament, in London, England is where the Bicameral Parliament (Nobility and the House of Commons) meets. The oldest part of the palace is Westminster Hall, still standing, dating from 1097. The palace was originally a king&apos;s residence but no kings have been there since the 16th century.</p><p>Big Ben Clock Tower: Completed in 1858, it is named after Benjamin Hall, the Architect of London, a great man. Designed by architects Charles Barry and Augustus Pugin in classic Gothic Revival style, this brick and limestone tower sits atop the Houses of Parliament. It is the largest four-faced clock tower in the UK. Each side is 23 feet (seven meters) in diameter and contains 312 pieces of opal glass.</p><p>Buckingham Palace (Outside): is a residence of the King of Great Britain in London, the official residence and also the main workplace of the British Royal Family. This palace was built in 1703 and is surrounded by three parks, including the famous Hyde Park. It was built to cater for special events of the country and for the royal family.</p><p>Building 10 Downing Street is known as (Number ten) where the British Prime Minister lives and works.</p><p>Parliament Square - Parliment square; Horse Guards Parade - The Royal Horse House of The Shard</p><p>Tower Bridge - This work combines a suspension bridge with a lift bridge over the Thames 12:30 Lunch at the restaurant. 14:00 Departure to check in hotel to rest.</p><p>18h00 Have dinner at the restaurant.</p><p><br></p><p>19h00 The car will pick you up and go to Renaisance Hotel London Heathrow to rest and free in the evening.</p>" },
                 new TourSchedule() { Id = "TOURSD_14", TourId = "TOUR_4", ScheduleOrder = 3, Name = "Day 3", Detail = "<p>07h00 Breakfast at the hotel.</p><p><br></p><p>08h00 You depart to visit the town of Amesbury (140kms from London ~ 02.00) - a small town in Wiltshire on the river Avon. Admire the natural wonder Stonehenge.</p><p><br></p><p>Stonehenge is located in the moors west of the village of Amusbawn, on the Salisbury Plain in southern England, 137 km southwest of London. The subject of this giant stone battle is a complex of large stone columns arranged in a circle. Each stone column is about 4m high, about 2m wide, about 1m thick, and weighs about 25 tons. In which, the two heaviest stone columns are about 50 tons. On some of the stone pillars, there are rocks that line up like rafters, forming a large archway. Around the concentric stone pillars circle is a moat 6m deep, about 21m wide. This trench is built into a wall. Inside the moat are 56 pits forming a circle. The pits are now filled with limestone, and inside are still human ashes. The ancient stone site of Stonehenge was recognized by UNESCO as a World Heritage Site in 1986. Then, you move to the city of Bath (64 km from Amesbury ~ 1.10).</p><p><br></p><p>12:30: Have lunch at the restaurant.</p><p><br></p><p>13h30: You depart to visit Bath City:</p><p><br></p><p>Royal Crescent - the second most beautiful street in England with two typical attractions: Royal Crescent and Royal Victoria Park.</p><p>Bath Abbey - was built in the 15th century in Gothic architecture. Roman Baths, which thousands of years ago were used as baths for kings, royalty and bishops. Where visitors can admire statues of Roman kings and soldiers or thousands of years old relics, tools of the ancients or a prayer pool with more than 12,000 sacred Roman coins.</p><p>Pulteney bridge - built by Robert Williams, along with Ponte Vecchio bridge (Florence) are the two most beautiful and romantic bridges in the world.</p><p>17h30: You depart for the city of Bristol (21kms~00.45 from Bath) - the sixth largest city in the UK with an estimated population of 44,250 people in 2015. This place has become a famous tourist destination in the UK by gas. The climate is warm due to the influence of winds blowing from the Atlantic Ocean bringing cool air and light rains 18:30: Dinner at the restaurant. 19:30 Depart for hotel check-in Hotel Hilton Garden Inn Bristol City Center or similar</p>" },
                 new TourSchedule() { Id = "TOURSD_15", TourId = "TOUR_4", ScheduleOrder = 4, Name = "Day 4", Detail = "<p>07h00 Breakfast at the hotel. After breakfast and hotel check-out, 08h00 car and tour guide will take you on the way to visit Strafford Upon Avon - Homeland of the great playwright William Shakespeare, his birthplace and final resting place. . Admire Anne Hathaway farm - Shakespeare&apos;s wife&apos;s house with a restored architecture of straw roof mixed with earth, looks very poetic. Around the house is a large garden with both flowers and fruit trees such as apples and pears. Here still retains the chair that young William Shakespeare used to sit on to flirt with Anne Hathaway when they were not married. 12:30: Have lunch at the restaurant. 13h30 Delegation will leave for Manchester, after dinner, the group will check in at Copthorne Hotel Manchester or equivalent to rest.</p>" },
                 new TourSchedule() { Id = "TOURSD_16", TourId = "TOUR_4", ScheduleOrder = 5, Name = "Day 5", Detail = "<p>07h00 Breakfast at the hotel 08h00 After breakfast and check out of the hotel. Car and HDV will take you to visit Manchester. Group visit: Manchester City Hall, Manchester cathedral, Millennium Lifting Footbridge - Famous works crossing the Manchester Canal, Manchester Opera House, Chinatown You will continue to visit the following spots: Stadium Old Trafford - the home ground of the Manchester United football team. Take pictures of the stadium. 12h00 Lunch at the restaurant 13h00 The car will take the group to Coatbridge city 18h30 Dinner at the restaurant 20h00 check in at Mondo Hotel and rest</p>" },
                 new TourSchedule() { Id = "TOURSD_17", TourId = "TOUR_4", ScheduleOrder = 6, Name = "Day 6", Detail = "<p>After having breakfast and checking out of the hotel, the car and tour guide will take the group to visit the city of Edinburgh with the following points</p><p><br></p><p>The Edinburgh castle: One of Edinburgh&apos;s top attractions Generations of Scottish kings and queens have lived in the Old Town and New Town fortresses: both boroughs are World Heritage Sites with approximately 4,500 recognized buildings ( highest concentration in the world).</p><p>Church of St. Giles&apos; Cathedral. Scott Monument, George Street, Holyrood Park, Scottish National Portrait Gallery</p><p>Scottish Parliament Building: built on the site of an old brewery, inaugurated in 2005. Here, visitors are guided free tours to some of the building&apos;s rooms.</p><p>Scotch Whiskey Heritage Center: a whiskey museum where you can discover the history and preparation of this drink. In the charming setting of the museum, you have the opportunity to sip a variety of whiskeys.</p><p>12:30 Lunch at the restaurant</p><p><br></p><p>13h00 The car will pick up the delegation to Harrogate city 18h30 Have dinner before returning to Cedar Court Hotel Harrogate to check in.</p>" },
                 new TourSchedule() { Id = "TOURSD_18", TourId = "TOUR_4", ScheduleOrder = 7, Name = "Day 7", Detail = "<div>07h00 Breakfast at the hotel 08h00 After breakfast, the car and guide will take the group to visit York City. Coming to York, the city with the most beautiful ancient citadel in Europe is York with a 5 km long surrounding wall, York was formerly a barrier to protect the city from the invasion of Vikings, Danes and Norman is on that side. The next point, the group will visit Holy Trinity Cathedral, it owns an incredible traditional architectural beauty, Holy Trinity is even more special when the entire lighting system does not need electricity. After lunch, the group will take a walk in the Shambles alley, built in the 14th century in the Middle Ages, right in the city center. 12h00 Lunch at the restaurant 13h00 car will take the delegation to Oxford city. 18h00 Check in hotel Double Tree Oxford Belfry. 18:30 Have dinner at the restaurant. You stay overnight at the hotel</div>" },
                 new TourSchedule() { Id = "TOURSD_19", TourId = "TOUR_4", ScheduleOrder = 8, Name = "Day 8", Detail = "<div>After breakfast at the hotel, you visit Oxford - a university city famous in the world for its poetic beauty, splendid ancient architecture and Oxford University. Arriving in Oxford, the group strolled around the city center, took photos with Oxford Town Hall, Oxford Covered Market operating from the 18th century to the present, Radcliffe Square, Radcliffe Camera, church nearly 800 years old Oxford (Christ Church). 10:30 Depart for Cotswolds 12:30 Have lunch at a restaurant 13h30 Delegation to visit Bibury - known as &quot;the most beautiful village in England&quot;, Bibury attracts tourists from five continents with its idyllic, peaceful but charming beauty. and visit: Fancy stone houses, which are mostly built of ancient sandstone and have existed for many centuries, bearing bold Cotswold architecture. 15:30 PM, transfer to London, group have dinner and return to Holiday Inn Brentford Lock to rest</div>" },
                 new TourSchedule() { Id = "TOURSD_20", TourId = "TOUR_4", ScheduleOrder = 9, Name = "Day 9", Detail = "<p>Have breakfast at Hotel. Car to take the group to visit</p><p><br></p><p>Trafalgar Square - built in memory of Lord Horatio Nelson&apos;s victory over the French and Spaniards at Trafalgar in 1805. Piccadilly Circus the unusual cross of several busy streets Piccadilly, Regent, Haymarket and Shaftesbury.</p><p><br></p><p>Visiting and taking pictures outside the Tower of London - London Tower - used to be the Royal Palace, where the queen&apos;s crown was kept, where this was a famous fortress and place of detention of famous figures who had been imprisoned. The Tower of London was recognized by Unesco as a world heritage site in 1988</p><p><br></p><p>Hyde Park - one of the 4 parks of the Royal Family, contributes to the green lung of the city and is considered one of the largest and most famous inner city parks in the world. Lunch at the restaurant</p><p><br></p><p>Afternoon: shopping tour on Oxford Street - the most luxurious shopping paradise in the UK, have dinner and return to Holiday Inn Brentford Lock to rest.</p>" },
                 new TourSchedule() { Id = "TOURSD_21", TourId = "TOUR_4", ScheduleOrder = 10, Name = "Day 10", Detail = "<p>You check out, car and tour guide will take the delegation to the airport for flight VN56 (11h00 - 04h50) to Hanoi. The delegation will return to Noi Bai airport.</p>" },
                 new TourSchedule() { Id = "TOURSD_22", TourId = "TOUR_4", ScheduleOrder = 11, Name = "Day 11", Detail = "<p>04h50: Return to Noi Bai airport.</p><p><br></p><p>The car picks up the group to the original rendezvous point. End of the journey and see you again</p>" },
                 new TourSchedule() { Id = "TOURSD_23", TourId = "TOUR_5", ScheduleOrder = 1, Name = "Day 1", Detail = "<p>Morning: Car and tour guide pick you up at the meeting point and transfer you to Noi Bai airport to check in for your flight to Quy Nhon:</p><p><br></p><p>Vietnam Airlines: flight VN1623 at 10:30am</p><p><br></p><p>Arriving at Phu Cat airport - Quy Nhon, the car and guide will pick you up and take you to the city. Quy Nhon, have lunch at a restaurant in the city.</p><p><br></p><p>Afternoon: Visit: Thien Hung Pagoda - the most beautiful and brilliant temple in Binh Dinh today. Ghenh Rang Tien Sa tourist area - Mong Cam slope, Thi Nhan hill, visit Han Mac Tu&apos;s grave, Hoang Hau beach, Tien Sa beach. You listen to explanations about the life and talented career of poet Han Mac Tu. Twin Towers - a cluster of towers with 02 ancient towers with Angkorian architecture, located right in the heart of Quy Nhon city. You are free to swim and relax.</p><p><br></p><p>Evening: Dinner at a restaurant in Quy Nhon city.</p><p><br></p><p>Overnight in Quy Nhon.</p>" },
                 new TourSchedule() { Id = "TOURSD_24", TourId = "TOUR_5", ScheduleOrder = 2, Name = "Day 2", Detail = "<p>Morning: Have breakfast at the hotel. Car and guide take the group to visit:</p><p><br></p><p>Ghenh Da Dia - a famous landscape that was ranked as a national historical site and landscape in 1998.</p><p><br></p><p>Mang Lang Church - an Ancient French architecture. Here you can admire the first book of Quoc Ngu script in Vietnam.</p><p><br></p><p>11h00: Continue to depart to O Loan Lagoon - have lunch with seafood specialties at a poetic place with gentle and romantic beauty.</p><p><br></p><p>Afternoon: Get on the bus to depart for Quy Nhon, relax and swim.</p><p><br></p><p>Evening: Have dinner at the restaurant. You are free to explore Quy Nhon - the hometown of many cultural celebrities - such as Quach Tan, Yen Lan, Han Mac Tu, Che Lan Vien, Trinh Cong Son...</p><p><br></p><p>Overnight in Quy Nhon.</p>" },
                 new TourSchedule() { Id = "TOURSD_25", TourId = "TOUR_5", ScheduleOrder = 3, Name = "Day 3", Detail = "<p>Morning: Have breakfast at the hotel.</p><p><br></p><p>08h00: Depart for Nhon Hai, cross Thi Nai Bridge - The bridge across the sea with a length of nearly 2.5km. You can stop, watch the golden rays sprinkled on Thi Nai Lagoon, hear about the heroic and tragic naval battles between Champa and Dai Viet, between the Tay Son and Nguyen Dynasty (Nguyen Anh) for more than 5 years. century.</p><p><br></p><p>08h30: You stop to visit and take souvenir photos of Phuong Mai Sand Dunes.</p><p><br></p><p>09h00: Arrive at the pier, you get on a canoe to explore Ky Co Island KDL (Tour price does not include the cost of going to Ky Co, you have to pay for it), with clear water, white sand, experience the feeling Diving. Have lunch on the island with attractive local seafood.</p><p><br></p><p>14h00: Cano bring the delegation back to the port, the car picks you up to visit:</p><p><br></p><p>Danh Thang Eo Gio - A windy rock year-round. Standing on Eo Gio, looking out into the distance, you can admire the vast vast sea, captivated people&apos;s hearts. Eo Gio, known as the most beautiful place to watch the sunset in Vietnam.</p><p>Tinh Xa Ngoc Hoa - Admiring the statue of Quan The Am about 30m high and the place to send the trust of the island people before going to sea and pray for their husband and children to always be safe, have smooth sailing, bring home The ship is full of fish and shrimp.</p><p>16h00: Car and guide take the group to the hotel, free to rest, swim in the sea.</p><p><br></p><p>Evening: Have dinner, discover local cuisine: seafood dishes, fish noodles, banh chung, pancakes, chicken specialties...</p><p><br></p><p>Overnight in Quy Nhon.</p>" },
                 new TourSchedule() { Id = "TOURSD_26", TourId = "TOUR_5", ScheduleOrder = 4, Name = "Day 4", Detail = "<p>Morning: Breakfast at the hotel. You wake up to watch the sunrise on the sea, walk and breathe the fresh air of the beautiful Quy Nhon beach. We check out the hotel. Car and guide take you to have lunch at the restaurant and buy local specialties for the family.</p><p><br></p><p>Afternoon: After lunch, the car will take you to Phu Cat airport for a flight to Hanoi Vietnam Airlines</p><p><br></p><p>Arriving at Noi Bai airport, the car picks you up at the original rendezvous point and bids you farewell. At the end of the program, the tour guide bids goodbye and hopes to see you again in the next journey.</p>" },
                 new TourSchedule() { 
                     Id = "TOURSD_27", 
                     TourId = "TOUR_6", 
                     ScheduleOrder = 1, 
                     Name = "Day 1", 
                     Detail = "<p>18h00: Car pick you up at the meeting point to Noi Bai international airport, exit procedures.</p><p><br></p><p>The delegation took a flight of Turkish national airline (Turkish Airlines) to Istanbul at 22:30. You stay overnight on the plane.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_28",
                     TourId = "TOUR_6",
                     ScheduleOrder = 2,
                     Name = "Day 2",
                     Detail = "<p>5:00: Arrive at Istanbul airport, do immigration procedures for Turkey. Car and local guide take you to breakfast, then visit Istanbul:</p><p><br></p><p>The Blue Mosque - The Blue Temple of the Osman Empire.</p><p>Basilica of Hagia Sophia - a cathedral built in the 6th century, a masterpiece of the Byzantine period, a precious monument of the world. Lunch at local restaurant.</p><p>Next, the group will visit the Basilica Cistern, an underground water tank system under the city of Istanbul. The ceiling of the Basilica Cistern is supported by 336 large marble columns, creating beautiful domes like in European synagogues.</p><p>Hippodrome Square - which used to be a horse racing arena with a capacity of more than 40,000 seats, where the blood of many gladiators fought through horse races.</p><p>Group lunch at the restaurant. After lunch, the group continues to visit</p><p><br></p><p>In the afternoon, you visit Topkapi Palace - the residence and working place of the Ottoman emperor, which can accommodate up to 4000 people serving the Royal Family. The palace is part of a historic complex in Istanbul that has been recognized by Unesco as a World Heritage Site since 1985.</p><p><br></p><p>Enjoy shopping at the Grand Bazaar - a 500-year-old market, with more than 4000 stalls selling everything from clothes, jewelry, food, handicrafts...</p><p><br></p><p>Dinner at the restaurant. Delegation to the hotel to rest.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_29",
                     TourId = "TOUR_6",
                     ScheduleOrder = 3,
                     Name = "Day 3",
                     Detail = "<p>5:00: Check out from the hotel, bring breakfast and move to the airport, take a flight to Izmir (07h00 - 8h00).</p><p><br></p><p>Upon arrival, the convoy departs for Kusadasi to visit the ancient city of Ephesus, known as the place where Mary and St. John lived and died here. Discovery team:</p><p><br></p><p>Selcuk and Ephesus - one of the ancient wonders of mankind. The delegation admires unique architectural works such as Celsius library, Hadrian temple, Marble and Agora street paved with stone and one of the ancient wonders of mankind, the largest theater in the ancient world Great Theater .</p><p>Temple of Artemis, which worships the goddess of hunting, daughter of Zeus - One of the 7 wonders of the ancient world.</p><p>Lunch at the restaurant.</p><p><br></p><p>After lunch, the group moves to Pamukale (190 km) to admire the remnants of the ancient city of Hierapolis and explore the &quot;Cotton Castle&quot;. The Holy City of Hierapolis is located in the southwest - south of Turkey and is recognized by Unesco as a World Cultural Heritage Site (unesco recognized in 1988). With the ravishing beauty of open-cast mineral springs thousands of years ago creating blue lakes on white rocks, these are unique natural wonders in the world. Visit and take pictures of Cotton Castle.</p><p><br></p><p>Overnight in Pamukkale.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_30",
                     TourId = "TOUR_6",
                     ScheduleOrder = 4,
                     Name = "Day 4",
                     Detail = "<p>Đo&agrave;n ăn s&aacute;ng, sau đ&oacute; trả ph&ograve;ng. Qu&yacute; kh&aacute;ch sẽ tiếp tục chuyến du ngoạn của m&igrave;nh đến với v&ugrave;ng đất linh thi&ecirc;ng Konya, một điểm dừng ch&acirc;n kh&ocirc;ng thể bỏ lỡ trước khi đến với Cappadocia. Tr&ecirc;n đường đi, Đo&agrave;n gh&eacute; thăm Caravanserai một dạng &ldquo;kh&aacute;ch sạn&rdquo; hay đ&uacute;ng hơn l&agrave; điểm dừng ch&acirc;n nằm tr&ecirc;n con đường tơ lụa huyền thoại, nơi m&agrave; c&aacute;c thương nh&acirc;n cổ xưa nghỉ ngơi v&agrave; lấy lại sức để tiếp tục h&agrave;nh tr&igrave;nh đến ch&acirc;u &Acirc;u bu&ocirc;n b&aacute;n.&nbsp;</p><p><br></p><p>Tu viện Mevlana hay c&ograve;n gọi lăng mộ của nh&agrave; hiền triết vĩ đại nhất của Thổ Nhĩ Kỳ, được người d&acirc;n t&ocirc;n thờ v&agrave; s&ugrave;ng b&aacute;i. Tiếp tục h&agrave;nh tr&igrave;nh đi Cappadocia.&nbsp;</p><p>Ăn trưa tại nh&agrave; h&agrave;ng.</p><p><br></p><p>Đến Cappadocia qu&yacute; kh&aacute;ch nhận ph&ograve;ng kh&aacute;ch sạn. Đo&agrave;n ăn tối. Nghỉ đ&ecirc;m tại Cappadocia.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_31",
                     TourId = "TOUR_6",
                     ScheduleOrder = 5,
                     Name = "Day 5",
                     Detail = "<p>Have breakfast at Hotel. In the early morning, you can register to watch the sunrise on a hot air balloon at Cappadocia - known as one of the best hot air balloon tourist destinations in the world (expenses excluded).</p><p><br></p><p>The team continues to explore:</p><p><br></p><p>Underground City - home to 15,000 Christians. The city will be a place to bring interesting experiences of bedrooms, churches, meeting rooms or food storage rooms located under the earth hum.</p><p>Visit Pigeon house - where there are a lot of pigeons and local people have made houses carved into the cliffs hum him pigeons shelter and breed.</p><p>Avanos ancient village - where two famous traditional trades are still kept: carpet weaving and ceramics.</p><p>After enjoying lunch, you continue to visit:</p><p><br></p><p>Goreme Uchisar residential area was built on a hill, with houses, restaurants, hotels, shops... carved deep into the cliff forming a unique residential area in the world.</p><p><br></p><p>Finally, you have the opportunity to admire the emerald exhibition of the Turks by designer Marco Polo.</p><p><br></p><p>Have dinner and enjoy a unique traditional Turkish dance show (free drinks). Overnight at the hotel</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_32",
                     TourId = "TOUR_6",
                     ScheduleOrder = 6,
                     Name = "Day 6",
                     Detail = "<p>After breakfast, check out to visit:</p><p><br></p><p>Devrent Valley, Pasabag</p><p>Relaxing mud bath, fish massage</p><p>Lunch at the restaurant. After lunch, transfer to the airport for a domestic flight back to Istanbul (15:20 - 16:40). Arrive in Istanbul, visit the central area of the City of Istanbul Sultan Ahmet Area, which is considered an important relic where cultural and historical values from the Byzantine and Ottoman times are kept. The relic area includes many outstanding works. Group dinner and back to the hotel to rest.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_33",
                     TourId = "TOUR_6",
                     ScheduleOrder = 7,
                     Name = "Day 7",
                     Detail = "<p>Group breakfast and hotel check out</p><p><br></p><p>Then enjoy the wonderful scenery of the Bosphorus Strait on the Bosphorus Cruise (about 2 hours) - enjoy the scenery on both sides of the strait, the magnificent palaces along the river.</p><p><br></p><p>The group took pictures with the beautiful Rumelia and Anatolia palaces. The group continued to visit:</p><p><br></p><p>Dolmabahce Palace - used to be the residence of many Presidents. The palace is brightly decorated with more than 4.5 tons of lanterns. The palace is large with more than 285 rooms and 46 large and small halls. Today, Dolmabahce welcomes thousands of international visitors every day and is still used as a meeting place for important national meetings.</p><p>Visit and shop at the famous spice market</p><p>After dinner, the car will take you to the airport to check in for a flight back to Vietnam. You return to Vietnam with unforgettable memories of a dynamic, modern but equally mysterious Turkey.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_34",
                     TourId = "TOUR_6",
                     ScheduleOrder = 8,
                     Name = "Day 8",
                     Detail = "<p>Delegation to Hanoi at 15:20 HDV helps you to do immigration procedures, receive luggage. End the tour, say goodbye and see you in the next trips.</p><p><br></p><p>Depending on actual conditions, the order of sightseeing may change but still ensure all attractions mentioned in the program.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_35",
                     TourId = "TOUR_7",
                     ScheduleOrder = 1,
                     Name = "Day 1",
                     Detail = "<p>07h15: The company&apos;s car and tour guide pick you up at the Opera House - Hanoi, take you to Noi Bai airport, take flight TG561 at 10:35 to Bangkok - Thailand</p><p><br></p><p>12:25: plane landed at Suvarnabhumi International Airport - Bangkok</p><p><br></p><p>16h20: You continue to depart for Dubai on flight TG517</p><p><br></p><p>19h45: Landing at Dubai International Airport, car and tour guide take the delegation to the hotel, check in, rest.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_36",
                     TourId = "TOUR_7",
                     ScheduleOrder = 2,
                     Name = "Day 2",
                     Detail = "<p>Morning: Have breakfast at the hotel.</p><p><br></p><p>You depart to ANURADHAPURA - The ancient capital of Anuradhapura, the city was built in the 5th century BC with many ancient monuments, especially the World cultural heritages. You visit and pay respects to the Buddhist relics here:</p><p><br></p><p>The Bodhi tree (Sri Maha Bodhiya) was brought by Bhikkhuni Sanghamitta to be planted in the island nation of Sri Lanka. The Bodhi tree is extracted from the Bodhi tree in Bodh Gaya, where the Buddha attained enlightenment. Bhikkhuni Sanghamitta is the sister of Bhikkhu Mahinda, who was the leader of a missionary group who brought Buddhism to the island in the 2nd century BC. The Ceylon people worship this ancient tree very much. They do not cut branches or prune branches, let the tree grow naturally, and use iron poles for support. When the tree branch was blown off by the wind, they picked it up and brought it back to worship. You enjoy the quiet space, the wind blows gently, cool, extremely happy in the main hall near the Bodhi tree, worshiping Buddha.</p><p>Lovamahapaya Palace (Brazen Palace) was built in the 3rd century BC to serve as the resting place of monks. Currently, only 1,600 stone columns remain, which are the foundation of a nine-story architecture with 9,000 rooms, the roof of the palace is covered with copper, hence the name Bronze Palace.</p><p>The Isurumuniya Stone Temple is famous for its many paintings and carvings of Buddha on the rock built by King Devanampiya Tissa.</p><p>Have lunch.</p><p><br></p><p>You continue to visit Mihintale Hill (Hill of Mahinda), the cradle of Buddhism in Sri Lanka. According to legend, the son of Emperor Ashoka of India went to Sri Lanka on the full moon day of the month of Poson (June), met King Devanampiyatissa and preached teachings to the king and his people. Mihinatale Hill has since become a sacred spot for Sri Lankan Buddhists. Visiting, Mihintale, visitors will go through 1,840 steps to reach the top, where visitors can enjoy the majestic natural landscape.</p><p><br></p><p>Have dinner at the restaurant.</p><p><br></p><p>Overnight at hotel Rajarata 4**** or equivalent in Anuradhapura.</p><p><br></p><p>Overnight in Anuradhapura.</p>"
                 }
                 );
            //Hãng xe
            context.CarBrands.AddOrUpdate(x => x.Id,
                 new CarBrand() { Id = "CARBR_1", Name = "Honda" },
                 new CarBrand() { Id = "CARBR_2", Name = "Toyota" },
                 new CarBrand() { Id = "CARBR_3", Name = "Mercedes" },
                 new CarBrand() { Id = "CARBR_4", Name = "KIA" },
                 new CarBrand() { Id = "CARBR_5", Name = "Hyundai" },
                 new CarBrand() { Id = "CARBR_6", Name = "Bentley" },
                 new CarBrand() { Id = "CARBR_7", Name = "Rolls-Royce" }
                 );
            //Mẫu xe
            context.CarModels.AddOrUpdate(x => x.Id,
                new CarModel() { Id = "CARMD_1", CarBrandId = "CARBR_1", Name = "Honda City" },
                new CarModel() { Id = "CARMD_2", CarBrandId = "CARBR_2", Name = "Camry 3.0" },
                new CarModel() { Id = "CARMD_3", CarBrandId = "CARBR_3", Name = "Maybach s600" },
                new CarModel() { Id = "CARMD_4", CarBrandId = "CARBR_4", Name = "KIA morning" },
                new CarModel() { Id = "CARMD_5", CarBrandId = "CARBR_5", Name = "Hyundai Tucson" },
                new CarModel() { Id = "CARMD_6", CarBrandId = "CARBR_6", Name = "Bentley Bentayga 2021" },
                new CarModel() { Id = "CARMD_7", CarBrandId = "CARBR_7", Name = "Rolls Royce Cullinan" }
                );
            //Kiểu xe
            context.CarTypes.AddOrUpdate(x => x.Id,
                new CarType() { Id = "CARTP_1", Name = "Small size" },
                new CarType() { Id = "CARTP_2", Name = "Full size" },
                new CarType() { Id = "CARTP_3", Name = "Luxury" },
                new CarType() { Id = "CARTP_4", Name = "Minivan" },
                new CarType() { Id = "CARTP_5", Name = "Sedan" },
                new CarType() { Id = "CARTP_6", Name = "Hatchback" },
                new CarType() { Id = "CARTP_7", Name = "roadster" }
                );
            //Xe
            context.Cars.AddOrUpdate(x => x.Id,
                new Car() { Id = "CAR_1", CarModelId = "CARMD_1", CarTypeId = "CARTP_1", LocationId = "LOCAL_1", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655619897/e2w/2020-Honda-City-Honda-T%C3%A2y-H%E1%BB%93-48_kljd5z.jpg", LisencePlate = "22-A-02757", HasAirConditioner = true, SeatCapacity = 5, PricePerDay = 43, Status = 1, CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now }
                );
            //Khách sạn
            context.Hotels.AddOrUpdate(x => x.Id,
                new Hotel() { Id = "HT_1", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655742974/e2w/images_hwseio.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655742932/e2w/download_asln5o.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655742956/e2w/images_hiasoq.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655742939/e2w/download_qh8ywj.jpg", Name = "Mon Regency Hotel", LocationId = "LOCAL_1", Rating = 5, Address = "1 PHAN DINH PHUNG, Hanoi, Vietnam", Price = 42.05, 
                    Description = "Located in the historic Old Quarter but within easy reach of the more laidback lakeside neighborhoods of West Lake and Truc Bach, Mon Regency is also close to Hanoi’s hotspots.",
                    Detail = "A step up from the deluxe rooms, the deluxe city view rooms allow you to enjoy fabulous views over Hanoi’s historic Old Quarter. Spot grand French colonial mansions, ancient temples, and century-old trees across Hanoi’s heart and soul. Within the room you’ll find a large and comfortable bed perfect for unwinding after a long day of sightseeing, as well as all the amenities one has come to expect from a modern boutique hotel, including an in-room station for preparing hot drinks, complimentary fresh flowers, and complimentary toiletries. The windows are sound-proof, meaning you can enjoy the view without being disturbed by the noise.", Status = 1, CreatedAt = Convert.ToDateTime("2017-08-09T23:49:58+02:00"), UpdatedAt = Convert.ToDateTime("2017-08-09T23:49:58+02:00"), DeletedAt = Convert.ToDateTime("2017-08-09T23:49:58+02:00") },
               new Hotel()
               {
                   Id = "HT_2",
                   Thumbnail = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/247138462.jpg?k=713a3bab8e26c9e4599ed193eb474e7eb4f62685aa4284c7caa9a0802da04f61&o=&hp=1 , https://cf.bstatic.com/xdata/images/hotel/max1024x768/235160460.jpg?k=4802d7b133c12a79540e9c3500f252dead7cbeeeb93d48a6109408029d3ef222&o=&hp=1 , https://cf.bstatic.com/xdata/images/hotel/max1024x768/235160466.jpg?k=3e69981e6c07c5c7da30777ccb388bc7fd5239c5e96a8cfa0ba2cfede47c563b&o=&hp=1 , https://cf.bstatic.com/xdata/images/hotel/max1024x768/248126446.jpg?k=505c6f4339fba8dc42f8bb4e31fc3e5a0206c9cb243eb8310750f0a3bd954c0a&o=&hp=1",
                   Name = "Hanoi Prime Center Hotel",
                   LocationId = "LOCAL_1",
                   Rating = 3,
                   Address = "36 Hang Huong, Quan Hoan Kiem , Ha Noi , Viet Nam",
                   Price = 25,
                   Description = "Hanoi Prime Center Hotel offers rooms with private balconies in the heart of Hanoi.Among the facilities of this property are a restaurant, a 24-hour front desk, room service and free WiFi.The property can arrange private parking for guests at an account surcharge.",
                   Detail = "Rooms at Hanoi Prime Center Hotel are equipped with a work desk, air conditioning,a flat - screen TV and a private bathroom with shower and bathrobes.Some rooms have a patio.All rooms at the property come with bed linen and towels.Among popular points of interest near Hanoi Prime Center Hotel are Dong Xuan Market, Hanoi Old City Gate and Thang Long Water Puppet Theater.The nearest airport is Noi Bai International Airport, 25 km away, and the hotel offers an airport shuttle service at a surcharge.",
                   Status = 1,
                   CreatedAt = Convert.ToDateTime("2017-08-09T23:49:58+02:00"),
                   UpdatedAt = Convert.ToDateTime("2017-08-09T23:49:58+02:00"),
                   DeletedAt = Convert.ToDateTime("2017-08-09T23:49:58+02:00")
               }
                );
            //Chuyến bay
            context.Flights.AddOrUpdate(x => x.Id,
                new Flight() { Id = "FL_1", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655743162/e2w/download_aalx9i.png", IsRoundTicket = true, DepartureId = "LOCAL_1", DestinationId = "LOCAL_3", DepartureAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), Duration = "3", Price = 43, ReturnAt = Convert.ToDateTime("2022-09-09T23:49:58+02:00"), Detail = "Brand : Vietnam Airlines - Flight : VN 600 - Boarding Time : 14:00", Status = 1, CreatedAt = Convert.ToDateTime("2017-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now }
                );
        }
    }
}