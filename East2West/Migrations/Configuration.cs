namespace East2West.Migrations
{
    using East2West.Data;
    using East2West.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<East2West.Data.DBContext>
    {
        private DBContext db = new DBContext();

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
            Random gen = new Random();
            DateTime RandomDay()
            {
                DateTime start = new DateTime(2018, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(gen.Next(range));
            }

            DateTime GetRandomDate(DateTime from, DateTime to)
            {
                var range = to - from;

                var randTimeSpan = new TimeSpan((long)(gen.NextDouble() * range.Ticks));

                return from + randTimeSpan;
            }


            for (int i = 1; i < 100; i++)
            {
                context.Users.AddOrUpdate(x => x.Id,
                new User() { Id = "USER_" + i, FirstName = "Vũ", LastName = "Anh", Address = "Ha Noi", PhoneNumber = "032115435" + i, Description = "Web developer", Thumbnail = "https://scontent.fhan2-4.fna.fbcdn.net/v/t39.30808-6/285445157_1412090459306899_7069453812980811907_n.jpg?_nc_cat=104&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=ve1SR0Xl-A8AX9BQO8l&tn=50u8vRJdElw1X9vW&_nc_ht=scontent.fhan2-4.fna&oh=00_AT8k9fGGrzDEiNWOEQ_OMtw_WcwUGLl9j5zh9t4XorVnxQ&oe=62BFE349", Email = "Jimmianh1807@gmail.com", Password = "0987888008", CreatedAt = DateTime.Now, Status = 1, LockoutEnabled = false, TwoFactorEnabled = false, AccessFailedCount = 0, UserName = "user" + i, PhoneNumberConfirmed = false }
                 );
            }

            //Địa điểm
                        context.Locations.AddOrUpdate(x => x.Id,
                            new Location() { Id = "LOCAL_1", Name = "Ha Noi", Description = "Hanoi is a dreamy city that has infatuated the human heart." },
                            new Location() { Id = "LOCAL_2", Name = "Bangkok", Description = "Bangkok, officially known in Thai as Krung Thep Maha Nakhon and colloquially as Krung Thep, is the capital and most populous city of Thailand." },
                            new Location() { Id = "LOCAL_3", Name = "Kathmandu", Description = "Kathmandu, officially the Kathmandu Metropolitan City, is the capital and the most populous city of Nepal " },
                            new Location() { Id = "LOCAL_4", Name = "Da Nang", Description = "Da Nang is a city directly under the central government, located in the South Central Coast region of Vietnam, is the central and largest city in the Central - Central Highlands region. " },
                            new Location() { Id = "LOCAL_5", Name = "Phu Quoc", Description = "Phu Quoc is an island located in the Gulf of Thailand and is the largest island in Vietnam. Administratively, Phu Quoc island, together with neighboring smaller islands and Tho Chu archipelago, 55 nautical miles to the southwest, composes Phu Quoc island city under Kien Giang province. " },
                            new Location() { Id = "LOCAL_6", Name = "Scotland", Description = "Scotland is a country in the United Kingdom of Great Britain and Northern Ireland. Scotland occupies the northern third of the island of Great Britain, is bordered by England to the south, the Atlantic Ocean surrounds the remaining sides: of which the North Sea is to the east, and the North Strait and the Irish Sea to the west -male." },
                            new Location() { Id = "LOCAL_7", Name = "Phu Yen", Description = "Phu Yen is known as a wild and beautiful land with many beaches, lagoons, historical and cultural relics such as Nhan Mountain, Da Bia Mountain, Vung Ro, Bai Mon - Mui Dien, O Loan lagoon, Ganh Da Dia, Mang Lang Church, Xuan Dai Bay, Dong Cam Dam. In addition, Phu Yen has many other scenic spots such as Bai Xep, Vinh Hoa beach, Tu Nham sand hill, Nua island, Chua island, Nhat Tu Son island, Bau beach, Yen island, Ganh Den, Cay Du waterfall, H'Ly waterfall. , Van Hoa Plateau..." },
                            new Location() { Id = "LOCAL_8", Name = "Turkey", Description = "Turkey is a democratic, secular, unitary, and constitutional republic with a diverse cultural heritage." },
                            new Location() { Id = "LOCAL_9", Name = "Sri Lanka", Description = "Sri Lanka, officially the Democratic Socialist Republic of Sri Lanka is an island nation with a majority Buddhist population in South Asia, located about 33 miles off the coast of the southern Indian state of Tamil Nadu. The country is often referred to as the 'Pearl of the Indian Ocean'." },
                            new Location() { Id = "LOCAL_10", Name = "Ha Long", Description = "Ha Long is the capital city of Quang Ninh province, Vietnam. The city is named after Ha Long Bay, the bay located to the south of the city and a famous heritage site of Vietnam. The name 'Ha Long' means 'dragon flying down'" },
                            new Location() { Id = "LOCAL_11", Name = "Ta Xua", Description = "Not only a bright spot on the province's tourist map, Ta Xua is also attractive with two famous specialties: ancient Shan Tuyet tea and meo apples." },
                            new Location() { Id = "LOCAL_12", Name = "Russia", Description = "Russia is a place of cultural exchange between Asia and Europe. If you have read information about Russia, you will see that Russia's area is extremely large, more than 17 million square kilometers." }
                            );
            context.TourCategories.AddOrUpdate(x => x.Id,
                new TourCategory() { Id = "TOURC_1", Name = "City Sightseeing" },
                new TourCategory() { Id = "TOURC_2", Name = "Historic Buildings " },
                new TourCategory() { Id = "TOURC_3", Name = "Museum tours " },
                new TourCategory() { Id = "TOURC_4", Name = "Walking tours " },
                new TourCategory() { Id = "TOURC_5", Name = "Eat & Drink " },
                new TourCategory() { Id = "TOURC_6", Name = "Churces" },
                new TourCategory() { Id = "TOURC_8", Name = "International" },
                new TourCategory() { Id = "TOURC_7", Name = "Skyline tours" }
                );

            // Tour
            context.Tours.AddOrUpdate(x => x.Id,
                new Tour() { Id = "TOUR_1", TourCategoryId = "TOURC_8", DepartureId = "LOCAL_1", DestinationId = "LOCAL_3", Name = "NAGARKOT SUNRISE TOUR", Description = "Coming to Nepal, it is impossible to ignore this ideal place to relax, the village of Nagarkot in Nepal is nestled next to the Himalayan mountainside like a miniature paradise in the majestic scenery of nature.", Detail = "Enjoy the best view of the Kathmandu valley on this hike. Discover rural traditions and exceptional hiking routes and admire the striking mountains and rural landscapes.", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656760637/e2w/nepal-pokhara-phewa-tal-lake-wallpaper-preview_n8kxny.jpg,https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655638385/e2w/download_dfibfd.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655741011/e2w/c25c92fc-Nagarkot-Sunrise-Tour_ddhk9b.webp , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655741058/e2w/28c46a14-Nagarkot-Sunrise-Tour_rxpiey.webp , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655741084/e2w/357b7a05-Nagarkot-sunrise-5_slmcls.webp", Duration = 3, Rating = 5, Policy = "BOOKING ON BEHALF OF OTHERS: If you make a booking for anyone other than yourself, you are considered the designated contact person for those other travelers. You represent and warrant that you are legally authorized to act on their behalf; that you have obtained all required consents; and that you will inform them of these Terms and warrant that they accept and agree to them. You are also responsible for making all payments due for your booking; notifying us if any changes or cancellations are required; and keeping the other travelers informed of all information relevant to your trip. REGISTRATION: After you complete your booking, we'll send you an email containing a link to a secure traveler registration form. For most packages, you must complete this form within 5 days of booking. Let us know if you are unable to complete it within this timeframe, or your booking may be subject to cancellation. CONFIRMATION: After we receive your booking and deposit, we will confirm availability of all components and send you a confirmation email within 1–2 business days. If any option or component you selected is not available, we will alert you and give you the option to modify your booking or to cancel and receive a refund of your deposit.", SummarySchedule = "Ha Noi - Nepal - Nagarkot ", Status = 1, CreatedAt = Convert.ToDateTime("2020-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
                new Tour() { Id = "TOUR_2", TourCategoryId = "TOURC_1", DepartureId = "LOCAL_1", DestinationId = "LOCAL_4", Name = "SERIES | HA NOI - DA NANG", Description = "SERIES | HANOI - DA NANG - BA NA - HOI AN", Detail = "Coming to Da Nang, visitors not only have the opportunity to visit the beautiful scenery of the sea but also have the opportunity to enjoy unforgettable special dishes, visit the charming natural scenery of the river and enjoy many famous specialties here. this. In addition, in the travel itinerary with Hanoitourist's Da Nang - Hoi An tour, you can also feel the peaceful beauty of Hoi An ancient town and the culinary beauty here.", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656760444/e2w/vietnam-h%E1%BB%99i-an-reflections-asia_hikq00.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655794879/e2w/63451_mwh9h0.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655794883/e2w/63453_nq69ji.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655794886/e2w/63455_vsf0fm.png", Duration = 4, Rating = 5, Policy = "<p>Price includes:</p><p>Air tickets and airport fees Hanoi - Da Nang - Hanoi (Vietnam Airlines ticket includes 20kg of checked baggage).</p><p>Modern air-conditioned cars exclusively for the group (with hand sanitizer on board)</p><p>Sekong 3 *** hotel on the seafront (early check-in time from 14h00; check-out at 12h00): 02 adults/room - odd group of guests use room 3, children sleep with parents without standard private room )</p><p>Meals according to the program 120,000 VND / person / main meal * 06 main meals. Breakfast buffet at the hotel.</p><p>You can take care of the entrance tickets at the tourist attractions in the program.</p><p>You can buy travel insurance throughout the route with a maximum compensation of 120,000,000 VND/person.</p><p>Guests are served cold towels, mineral water in the car, the norm is 1 bottle / person / day, the limit is 1 mask / day / person.</p><p>Tour guide picks you up at the airport in Hanoi</p><p>Tour guide in Da Nang, enthusiastic experience, explain the route, serve the group according to the program.</p><p>Price does not include:</p><p>Cable car tickets &amp; games at Ba Na + Eating Ba Na resort: 850,000 VND/pax (fares may change at the time of using the service)</p><p>If going to Cu Lao Cham: 600,000 VND/pax</p><p>If going to Vinpearl Nam Hoi An: 700,000 VND/pax.</p><p>Single room sleep, drinks. Personal expenses other than the program.</p><p>Tipping for drivers and guides.</p><p>SUPPLY FOR SINGLE ROOM: 1,100,000 VND</p><p>Cancellation policy:</p><p>Note:</p><p><br></p><p>The order of attractions can be changed to match the actual program of the group, but still ensure the full range of attractions.</p><p>Flight time may change according to flight time of Vietnam Airlines.</p>", SummarySchedule = "HANOI - DA NANG - BA NA - HUE - HOI AN - HANOI", Status = 1, CreatedAt = Convert.ToDateTime("2020-08-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
                new Tour() { Id = "TOUR_3", TourCategoryId = "TOURC_1", DepartureId = "LOCAL_1", DestinationId = "LOCAL_5", Name = "EXPLORE PHU QUOC", Description = "SERIES | HANOI - PHU QUOC", Detail = "Explore Phu Quoc pearl island which is known as the island paradise of Vietnam in 3 days 2 nights.", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656760413/e2w/sunrise-phu-quoc-island-ocean_ngz3jx.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655799709/e2w/63543_h9i0wo.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655799719/e2w/63545_imuz24.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655799724/e2w/63547_ubullo.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655799733/e2w/63549_d8sfxk.png", Duration = 4, Rating = 5, Policy = "<p>Price includes:</p><p>Air tickets and airport fees Hanoi - Phu Quoc - Hanoi with BamBoo Airways: group tickets, non-refundable, non-cancellable, unchanged (including 07kg hand baggage, 20kg checked baggage)</p><p>New air-conditioned cars according to the schedule in Phu Quoc.</p><p>Airport pick-up and drop-off from Hanoi - Noi Bai and vice versa</p><p>Standard hotel rooms 3 *, 4 *, 5 * depending on your choice. 02 people/room, if odd men or women use room 03 people.</p><p>3* Hotel: Hotel Happy Phu Quoc 3* or equivalent</p><p>4* Hotel: Sonaga Resort 4* or equivalent</p><p>5* Hotel: Best Western Sonasea Phu Quoc 5* or equivalent</p><p>Meals according to the program: Main meals: 05 meals x 150,000 VND/person/meal, including 01 meal on board. Have breakfast at Hotel.</p><p>Fishing boat, coral viewing, fishing gear, bait, tools.</p><p>Enthusiastic, experienced tour guide welcomes you at Noi Bai airport and follows you throughout the journey in Phu Quoc.</p><p>Sightseeing fees for the first entry points in the program.</p><p>Travel insurance throughout the route (maximum compensation 120,000,000 VND/case).</p><p>Drinking water in the car 01 bottle/person/day.</p><p>Tax</p><p>Price does not include:</p><p>Expenses for swimming, entertainment and personal expenses.</p><p>Round trip ticket for Hon Thom cable car 540,000 VND (According to regulations of Sun Group).</p><p>Tickets for entrance fees at Grand World: Bear Museum 200,000 VND/person, Essence of Vietnam 200,000 VND/person, river cruise 200,000 VND/person. (According to Vin Group&apos;s regulations)</p><p>Personal expenses and other expenses incurred outside the program, sleeping in a single room, overtime travel, drinks, etc.</p><p>Tips for tour guide and driver</p><p>Cancellation policy:</p><p>If you cancel the tour after registration or before 15 days of departure: tour deposit fee will be forfeited</p><p>If you cancel the tour from 10 to 15 days before the departure date: cancellation fee of 70% of the tour value.</p><p>If you cancel the tour within 10 days before departure date: 100% cancellation fee of tour value.</p><p>&nbsp;</p><p><br></p><p>Note : Whichever condition comes first, we will apply that condition.</p>", SummarySchedule = "HANOI - DA NANG - BA NA - HUE - HOI AN - HANOI", Status = 1, CreatedAt = Convert.ToDateTime("2020-06-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
                new Tour() { Id = "TOUR_4", TourCategoryId = "TOURC_8", DepartureId = "LOCAL_1", DestinationId = "LOCAL_6", Name = "ENGLAND TOUR", Description = "ENGLAND & SCOTLAND TOUR - LAND OF MOT", Detail = "Price includes urgent visa service. Comfortable 4-star hotel, convenient to visit. Enjoy the taste of typical European dishes. Experienced and enthusiastic guides throughout the route. Visiting Big Ben Clock Tower, Buckingham Palace,.. Visit Bibury Ancient Village - The oldest village in England.", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656760353/e2w/london-england-thames-river-body-of-water-wallpaper-preview_i91xte.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802108/e2w/67488_iyg82d.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802112/e2w/67491_ttrya2.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802120/e2w/67494_wqnyfn.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802129/e2w/67552_zid7uq.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802136/e2w/67555_dvkhsi.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802143/e2w/67558_fbiorb.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802150/e2w/67561_cyxazm.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802155/e2w/67577_odfz6o.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802163/e2w/67564_kphogt.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802173/e2w/67596_gw4bol.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802180/e2w/67599_datxs3.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802188/e2w/67637_roskwn.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802199/e2w/67643_hsbkmk.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655802204/e2w/67640_fjmq5i.png", Duration = 11, Rating = 5, Policy = "<p>Price includes:</p><p>Round trip airfare of Vietnamairlines</p><p>Airport fee + airline tax.</p><p>4* standard hotel</p><p>Meals according to the program are from 18 GPB - 20 GPB/meal.</p><p>Tickets to visit places according to the program. Admission to Stonehenge and Scotch Whiskey</p><p>Cars are transported according to the program (10 hours/day)</p><p>Vietnamese tour guide throughout the route from Vietnam</p><p>&nbsp; Fee for translating documents and procedures for UK visa (non-refundable cost 6,000,000 VND) &ndash; The current UK visa application period needs at least 12 weeks</p><p>MIC travel insurance coverage up to 50,000 USD/person/case</p><p>Gifts of Hanoi Tourist</p><p>VAT according to government regulations 0% service abroad and 8% domestic service</p><p>Price does not include:</p><p>Passport fee.</p><p>Tipping for tour guide and driver (about 7 GBP / 1 pax / 1 day tour).</p><p>Personal costs</p><p>Excess baggage</p><p>Excursions outside the program</p><p>Surcharge for single room stay (if any).</p><p>Extra tips for drivers and guides if the time limit is over.</p><p>Urgent visa fee (8,000,000 VND) (If any)</p><p>Cancellation policy:</p><p>Note:</p><p>For objective reasons, the program or route may change or the contents of the itinerary will be rearranged (but still ensuring the existing contents).</p><p>Visiting the cities listed in the program, in case you need services to get out of these cities to a place not listed in the program, you must satisfy agreement on increased costs.</p><p>Request you to comply with the scheduled time, if due to force majeure objective reasons (traffic jams...) or because of your own wishes with the consensus of all members of the team working on time. If there is a shortage of time for that day&apos;s itinerary, it is possible that the next destinations on that day will be skimmed or have to be omitted.</p><p>We are not responsible for refunding services in the program that you do not use.</p><p>We are not responsible for any delay on your part.</p><p>During the journey, you are not allowed to automatically receive more family members or acquaintances on the bus without a service agreement with us in advance.</p><p>Flight and flight time, airline, flight date may change depending on the visa issuance schedule of the embassy. Vehicles transported in England - Scotland will travel no more than 10 hours/day.</p>", SummarySchedule = "LONDON - AMSBURY - BATH - BRITOL - STRAFFORD - UPON - AVON - MANCHESTER - EDINBURGH - YORK - OXFORD - BIBURY - LONDON", Status = 1, CreatedAt = Convert.ToDateTime("2021-09-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
                new Tour() { Id = "TOUR_5", TourCategoryId = "TOURC_1", DepartureId = "LOCAL_1", DestinationId = "LOCAL_7", Name = "SERIES | TOURISM TUY HOA", Description = "Phu Yen is developing strongly and is becoming an interesting stop on the tourist map of Vietnam.", Detail = "Conquer Phuong Mai sand dune - the place is known as - A desert in the heart of the blue sea. Sightseeing: Da Dia Ghenh, O Loan lagoon, Mang Lang Church - An ancient French architecture. Twin Towers - a cluster of towers with 02 ancient towers with Angkorian architecture, built in the 12th century. - Cathedral Church. Visit Ghenh Rang Tourist Area with Thi Nhan Hill, Mong Cam Doc, Visit Tomb of poet Han Mac Tu, Fire Pen Dzu Kha,...", Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656760251/e2w/the-sea-rock-volcano-cliff_yjneco.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811416/e2w/119178_fqnlmn.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811302/e2w/74272_vrooht.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811305/e2w/74275_ilyihw.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811312/e2w/74278_ogpcbm.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811318/e2w/74281_jqre1y.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811323/e2w/74284_penfq1.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811334/e2w/74287_cg1s4a.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1655811342/e2w/74290_yl6cfe.png", Duration = 4, Rating = 4.5, Policy = "<p>Price includes:</p><p>Round-trip flight ticket Hanoi - Quy Nhon - Hanoi (Non-refundable, non-cancellation, change) of Vietnamairlines: including 10kg hand luggage and 1 piece of 23kg checked baggage</p><p>Private transportation service according to the program</p><p>3-star standard hotel according to the program (Flora, Rustic, Yen Vy 4 hotels or equivalent): 02 people/room, if odd, triple room. Children under 12 years old sleep with parents, no standard room.</p><p>Meals according to the program: Breakfast at the hotel. Standard meal 130,000 VND/person/meal x 06 meals.</p><p>Tickets to visit 1 time at the attractions according to the program.</p><p>Experienced tour guide, enthusiastic service according to the program in Quy Nhon &amp; Tuy Hoa</p><p>Guide to pick up &amp; drop off the airport in Hanoi</p><p>Drinking water: 01 bottle of mineral water 500ml/person/day in the car</p><p>Travel hat gift</p><p>Travel insurance pays up to 120,000,000 VND/person/case (depending on each incident)</p><p>VAT invoice as prescribed</p><p>Price does not include:</p><p>Drinks and personal expenses are not included in the program</p><p>Cost of single room (if any)</p><p>Ky Co tour cost (including 1 seafood lunch): 420,000vnd/adult</p><p>Tipping for guides and drivers.</p><p>Cancellation policy:</p><p>Conditions of tour cancellation:</p><p>If you cancel the tour after registration and 30 days before departure: tour deposit fee will be forfeited</p><p>If you cancel the tour from 15-30 days before departure date: 50% cancellation fee of tour value.</p><p>If you cancel the tour from 07-15 days before departure date: 70% cancellation fee of tour value.</p><p>If you cancel the tour within 07 days before departure date: 100% cancellation fee of tour value.</p><p>(Note: Whichever comes first we will apply.)</p><p><br></p><p>Conditions for air tickets:</p><p>Flight time is subject to change according to the airline&apos;s flight time.</p><p>When traveling by plane, you should bring one of the following documents: (valid ID card, ID card, or passport with more than 6 months validity,... birth certificate (for children under 6 months old) 14 years old).</p><p>If you cancel the tour due to being refused to check in at the airport due to identity / identification The travel agency is not responsible for the above incident. Program costs will not be refunded in this case.</p><p>Conditions of safe reception:</p><p>Comply with the &ldquo;5K Message&rdquo;</p><p>Medical declaration according to regulations</p><p>Comply with Hanoitourist&apos;s epidemic prevention and control instructions.</p><p>General regulations:</p><p>Due to the nature of the group, if the group has 10 adults or more, the group will depart on the same day. If the group does not have enough 10 guests, Party B will arrange a new departure date and notify Party A 15 days in advance.</p><p>If Party B does not organize for the delegation to go at the scheduled time due to force majeure causes such as natural disasters, storms, floods, war.... Party B will arrange a new departure date, all costs incurred shall be agreed upon by both parties.</p><p>Price from</p><p><br></p><p>VND 6,290,000</p><p><br></p><p>KEEP ONLY</p><p><br></p><p>REGISTER FOR CONSULTATIONS</p><p><br></p><p>Hotline: 19004518</p><p><br></p><p>Tags: Quy Nhon travel experience, Quy Nhon tourism, Discover Quy Nhon</p><p>ALL QUESTIONS PLEASE CONTACT US</p><p>Phone</p><p>Hotline:</p><p>19004518</p><p>Mail</p><p>Email:</p><p>sales@hanoitourist.vn</p><p>OR LEARN INFORMATION</p><p>First and last name</p><p>Enter your first and last name</p><p>Email or Phone Number</p><p>Enter your email or phone number</p>", SummarySchedule = "HANOI - QUY NHON - TUY HOA - HANOI", Status = 1, CreatedAt = Convert.ToDateTime("2021-01-09T23:49:58+02:00"), UpdatedAt = DateTime.Now, DeletedAt = DateTime.Now },
                new Tour()
                {
                    Id = "TOUR_6",
                    DepartureId = "LOCAL_1",
                    TourCategoryId = "TOURC_8",
                    DestinationId = "LOCAL_8",
                    Name = "TOUR TURKEY",
                    Description = "As a country located between the two continents of Asia - Europe, Turkey attracts tourists by its unique cultural beauty, amazing natural scenery and diverse cuisine. In particular, the following tourist attractions in Turkey will help visitors go back in time to the ancient times with many monuments, monumental historical works or discover unique natural wonders. unique in the world,....",
                    Detail = "Stay 2 nights in a 4-star hotel in Cappadocia and 2 nights in Istanbul full of the most unique attractions.Experience the sunrise on a hot air balloon in the rock city of Cappadocia.Admire countless mysterious ancient monuments in Istanbul, Kudasadi, Pamukale with typical examples being the world wonder of the ancient citadel of Ephesus, the ancient wonder of the Temple of Atemis, etc. Natural wonder 'Cotton Castle' Pamukale.Cruise on the Bosphorus Strait connecting the 2 continents of Eurasia.Experience mud bath, fish massage.Free 1 belly dance dinner + free flow drink in Cappadocia",
                    Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656760119/e2w/city-cityscape-istanbul-turkey-wallpaper-preview_oy5fkd.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656339364/e2w/67714_mdlxf7.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656339370/e2w/67772_zo3ptf.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656339376/e2w/67775_lj0s9y.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656339395/e2w/67790_odx5r0.png ",
                    Duration = 8,
                    Rating = 4.5,
                    Policy = "Stay 2 nights in a 4-star hotel in Cappadocia and 2 nights in Istanbul full of the most unique attractions.Experience the sunrise on a hot air balloon in the rock city of Cappadocia.Admire countless mysterious ancient monuments in Istanbul, Kudasadi, Pamukale with typical examples being the world wonder of the ancient citadel of Ephesus, the ancient wonder of the Temple of Atemis, etc. Natural wonder 'Cotton Castle' Pamukale.Cruise on the Bosphorus Strait connecting the 2 continents of Eurasia.Experience mud bath, fish massage.Free 1 belly dance dinner + free flow drink in Cappadocia",
                    SummarySchedule = "HA NOI - ISTABUL - IZMIR - KUSADASI - PAMUKALE - KONYA - CAPPADOCIA - ISTANBUL - HA NOI",
                    Status = 1,
                    CreatedAt = GetRandomDate(DateTime.Now.AddYears(-4), DateTime.Now)
                },
                new Tour()
                {
                    Id = "TOUR_7",
                    DepartureId = "LOCAL_1",
                    TourCategoryId = "TOURC_8",
                    DestinationId = "LOCAL_9",
                    Name = "DISCOVER THE INDIAN PEARL SRI LANKA",
                    Description = "Sri Lanka has always been called the 'Pearl of the Indian Ocean'. Surrounding this country is the vast ocean, so it has many beautiful pristine beaches. One of them must mention Tangalle. This beach is located in Hambantota province, in the southern region of the country. Coming to Tangalle, any visitor must be impressed by the peaceful, unspoiled scenery with blue sea, white sand and straight coconut trees. Not only is this a place to swim, this is also a great place for you to snorkel, surf and enjoy fresh seafood.",
                    Detail = "Welcome to Sri Lanka and make the most of this opportunity to visit the best places of interest in this magnificent Island. As you step into an Island with enchanting atmosphere and a breathtaking nature we offer you tour choices covering a great variety of remarkable and outstanding places that gets your tour interesting by the minute. Beach lovers can finally explore the finest tropical sandy beaches, experience jungle trekking and wild life safaris, visit ancient places with historical values and learn more about how Sri Lankan ancestors lived back then and the unmatched beauty in hill country.",
                    Thumbnail = " https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656759912/e2w/sri-lanka-historical-forest-hd-wallpaper-preview_rhnmyi.jpg, https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656417081/e2w/184991_brd2gm.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656417049/e2w/184974_vrgfmk.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656417061/e2w/184978_fpbmqh.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656417074/e2w/184987_y8w5uw.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656417088/e2w/184995_melcmd.jpg",
                    Duration = 6,
                    Rating = 4,
                    Policy = "<p>Price includes:</p><p>Car pick up and drop off Noi Bai airport.</p><p>Round-trip airfare Hanoi // TP. HCM - Colombo - Hanoi // City. Ho Chi Minh City of Singapore Airlines, natural goods and domestic air tax (7 kg hand baggage, 25 kg checked baggage)</p><p>Car transportation to visit according to the program.</p><p>Visa to enter Sri Lanka.</p><p>04 4 * hotels, 2 guests / room, odd guests sharing rooms of the same sex (odd male pairing male / odd female pairing female)</p><p>Meals and dinners at local restaurants.</p><p>01 dimensional PCR check for each customer</p><p>Entrance key to the entrance (1st time) according to the program</p><p>Local support guides during the tour in Sri Lanka and professional and enthusiastic online Vietnamese guides Travel insurance with maximum value (Medical or unexpected incident: 1 Billion VND. 400 million accidents)</p><p>Confidential Covid-19 - 30 days in hospital according to Sri Lankan regulations</p><p>Hanoitourist Hat + 01 bottle of mineral water / person / day</p><p>Price does not include:</p><p>&nbsp; &nbsp; &nbsp;Tip for driver and guide: 30 USD/pax.</p><p>The cost of PCR testing in Vietnam on the exit server.</p><p>Personal expenses not included in the program</p><p>Admission tickets at attractions outside the program</p><p>Separate room costs (if any)</p><p>For overseas Vietnamese who have a one-time visa to Vietnam, they must apply for a border gate visa to re-enter Vietnam (please contact for advice).</p><p>Roleprouctures:</p><p>Note:</p><p>1. The above prices apply to large customers, not during holidays, Tet or peak seasons.</p><p><br></p><p>2. If you are a vegetarian, please bring more vegetarian food to secure your place.</p><p><br></p><p>3. Visa key is not completed whether visa has been issued or not.</p><p><br></p><p>4. The program schedule can be changed to match the flight schedule and the local restaurant naturally ensures that enough reference points are updated in the program.</p><p><br></p><p>5. Visa application file:</p><p><br></p><p>02 new photos of 3.5 x 4.5 cm, clear, white background.</p><p>Original projection is limited to more than 6 months, submitted 15-20 days before launch.</p><p>Proving work and finance (if any)</p><p>Officially the program has been confirmed 1-2 days before the launch date. The schedule can change properties to weather, information interface but still ensure the full range of attractions.</p>",
                    SummarySchedule = "HA NOI - SRI LANKA - HA NOI",
                    Status = 1,
                    CreatedAt = GetRandomDate(DateTime.Now.AddYears(-4), DateTime.Now)
                },
                new Tour()
                {
                    Id = "TOUR_8",
                    DepartureId = "LOCAL_1",
                    DestinationId = "LOCAL_10",
                    Name = "HA LONG BAY ",
                    Description = "With its picturesque beauty, Ha Long Bay is recognized by UNESCO as a natural wonder of the world. The presence of thousands of islands and caves unspoiled, mysteriously beautiful and rich in ecosystems, Ha Long Bay has become an extremely unique destination that any tourist wants to visit. A famous island and cave in Ha Long Bay you can refer to such as: Ga Choi island, Ngoc Vung island, Con Coc island, Ti Top island, Sung Sot cave...",
                    TourCategoryId = "TOURC_1",
                    Detail = "Cat Ba Island is a giant green carpet containing many mysteries and attractions. Cat Ba deserves to be the 3rd biosphere reserve in Vietnam, now recognized by UNESCO as a world biosphere reserve. ",
                    Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656759838/e2w/junk-ha-long-bay-vietnam-sailing-ship-wallpaper-preview_cgizqx.jpg ,https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656492924/e2w/67761_boetpm.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656492915/e2w/67758_lzlp9d.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656492937/e2w/67767_hqqcfn.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656492907/e2w/67740_hzpsdi.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656492905/e2w/67737_vwg9n7.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656492883/e2w/67664_rwntai.png",
                    Duration = 3,
                    Rating = 4.5,
                    Policy = "<p>Price includes:</p><p>Modern and new means of transport served according to the program:</p><p><br></p><p>o Modern air-conditioned cars exclusively for groups (45-seat aero space car, 35-seat hyundai town car, 24-29-seat county car, 16-seat ford transit, mercedes benz).</p><p><br></p><p>Stay:</p><p><br></p><p>o You stay at the hotel in the center of the hotel, with comfortable rooms with air conditioning, television, and self-contained heating and cooling for 2 people per room.</p><p><br></p><p>o In Cat Ba: QK3***, Sea pearl***, Sunflower*** or equivalent</p><p><br></p><p>o In Ha Long: BMC Thang Long***. Van Hai***, Union*** or equivalent</p><p><br></p><p>Eat meals according to the program at the hotel restaurants specializing in serving tourists.</p><p><br></p><p>o Standard meal of 150,000 VND/person/meal (5 meals)</p><p><br></p><p>o Breakfast buffet at the hotel.</p><p><br></p><p>Visit</p><p><br></p><p>o You can take care of sightseeing tickets at tourist attractions: tickets to visit Ha Long Bay, Cat Ba National Forest.</p><p><br></p><p>o Tickets to visit and see performances at Tuan Chau island</p><p><br></p><p>o High-speed train ticket Hai Phong - Cat Ba</p><p><br></p><p>o Car to visit Cat Ba National Forest</p><p><br></p><p>o Boat pick up Gia Luan pier (Cat Ba) and visit Ha Long Bay</p><p><br></p><p>Travel insurance:</p><p><br></p><p>o You can buy travel insurance throughout the route with a maximum compensation of VND 10,000,000/person.</p><p><br></p><p>Other services:</p><p><br></p><p>o You are served cold towels, mineral water in the car, the norm is 1 bottle/person/day.</p><p><br></p><p>Tour guide:</p><p><br></p><p>o Enthusiastic experience, route explanation, serving group meals according to the program.</p><p><br></p><p>Price does not include:</p><p>o Tickets to the resort and watch shows at Tuan Chau: 350,000 VND / person.</p><p><br></p><p>o Single room, drinks. Other personal expenses outside the program.</p><p><br></p><p>Cancellation policy:</p>",
                    SummarySchedule = "CAT BA ISLAND - HA LONG - TUAN CHAU",
                    Status = 1,
                    CreatedAt = GetRandomDate(DateTime.Now.AddYears(-4), DateTime.Now)
                },
               new Tour()
               {
                   Id = "TOUR_9",
                   DepartureId = "LOCAL_1",
                   DestinationId = "LOCAL_12",
                   Name = "TRAVEL SPRING LAND",
                   TourCategoryId = "TOURC_1",
                   Description = "Duong Lam ancient village - which is less than 50km from the center of Hanoi. To this day, Duong Lam ancient village still the basic features of a village in the North with village gates, banyan trees, water wharf, communal yard, etc. with 956 traditional houses.",
                   Detail = "Duong Lam - for tourists who love to experience, want to immerse themselves in an ancient and bold space, so that they can feel the culture of their ancestors along the length of history. Each village, monument or temple has its own imprint associated with famous characters or memorable historical stories. You must come to feel, see and hear the words of the old guides to fully experience this place.",
                   Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656759782/e2w/lang-co-duong-lam-ha-noi-12_aqzlgb.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656526584/e2w/176394_urtfqs.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656526591/e2w/176398_unmqjg.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656526601/e2w/176406_b0or3z.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656526605/e2w/176410_rsdvet.jpg",
                   Duration = 1,
                   Rating = 4.5,
                   Policy = "<p>Price includes:</p><p>01 guide car</p><p>01 lunch according to the program, the meal rate is 150,000 VND / meal</p><p>Sightseeing tickets are included in the program</p><p>Enthusiastic and experienced tour guide throughout the route</p><p>Travel hats</p><p>Travel insurance</p><p>Price does not include:</p><p>The cost of car rental and self-drive gas for customers</p><p>Drinks on meals</p><p>Other personal expenses</p><p>Tips for driver and guide</p><p>Cancellation policy:</p><p>You should note:</p><p><br></p><p>You must bring: legal identification (ID card or Passport)</p><p>You should bring: insect repellent, common cold medicine</p><p>If you are a vegetarian, please bring more vegetarian food to ensure your taste</p><p>Any service in the tour, if you do not use it, will not be refunded</p><p>The tour guide has the right to rearrange the order of attractions to suit the conditions of each specific departure date, but still ensure all attractions in the program.</p><p>At the end of the tour, we will drop off guests at a single point, the Hanoi Opera House. Please take a taxi to your hotel or accommodation by yourself.</p><p>Customer Responsibilities:</p><p><br></p><p>Customers are solely responsible for their health and chronic diseases (cardiovascular, blood pressure, diabetes, osteoarthritis, etc.), congenital diseases, underlying diseases, HIV AIDS, mental and neurological disorders, pregnant women... are diseases not covered by insurance. When necessary, you must write a commitment about your illness when participating in the tour. Tour organizer</p><p>is not responsible for the cases where you do not declare the disease, declare dishonestly as well as the cases outside the travel insurance coverage in the tour.</p><p>Customers must take care of their own property in all cases and in all places during the trip. The tour organizer is not responsible for the loss of money, valuables, airline tickets, and customer&apos;s private property during the trip.</p><p>Conditions for safe reception of Hanoitourist guests:</p><p><br></p><p>&nbsp;</p><p><br></p><p>Pursuant to regulations on prevention and control of Covid-19 epidemic of competent authorities and local health.</p><p>Pursuant to temporary guidance document No. 3862/HD-BVHTTDL dated October 18, 2021.</p><p>Guests from epidemic areas with level 1, 2: only need to declare health, inject full dose of vaccine.</p><p>Visitors from epidemic level 3 and 4 areas, depending on the regulations of the destination.</p><p>Please cooperate with Hanoitourist in epidemiological investigation within 14 days before departure date.</p><p>Bring full legal identification (ID card/CCCD or passport).</p><p>Comply with the &quot;5K Message&quot;, make medical declarations as required and comply with Hanoitourist&apos;s epidemic prevention and control guidelines.</p><p>Check the translation level at: https://capdodich.yte.gov.vn/map</p><p>The program and recipients may change according to the actual local epidemic situation.</p>",
                   SummarySchedule = "Duong Lam Ancient Village - Cane Pagoda - Ngo Quyen Temple and Tomb - Duoi Range - Va Temple - Inner City of Hanoi",
                   Status = 1,
                   CreatedAt = GetRandomDate(DateTime.Now.AddYears(-4), DateTime.Now)
               },
               new Tour()
               {
                   Id = "TOUR_10",
                   DepartureId = "LOCAL_1",
                   DestinationId = "LOCAL_1",
                   Name = "TOUR TA XUA ",
                   TourCategoryId = "TOURC_1",
                   Description = "Ta Xua Hunting Clouds is one of the most 'hot' phrases in recent times in the community of travel believers. So in the end, what is so beautiful about Ta Xua that makes people so crazy? And how to go to Ta Xua, what month to go, .. are the questions of many young people.",
                   Detail = "<p>Ta Xua is hailed as one of the most beautiful cloud paradises in the North. Standing in front of the Ta Xua sea of clouds, we feel like we are lost in a wonderful paradise forgotten in the world. Time seems to slow down in this &quot;fairytale&quot; place. Are you ready to travel Hanoitourist and &quot;hunt clouds&quot; in this paradise during this Lunar New Year? Let&apos;s review the highlights of the wonderful experience in 2 days and 1 night</p>",
                   Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656759714/e2w/a7e1582b5fff174a2632fa4cfac80662_dohbph.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656527472/e2w/182555_vjlabo.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656527477/e2w/182559_sa8l7z.jpg, https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656527486/e2w/182567_vzbxcm.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656527492/e2w/182571_mvfdhy.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656527500/e2w/182575_fdgcvd.jpg",
                   Duration = 2,
                   Rating = 5,
                   Policy = "<p>Price includes:</p><p>01 Transport vehicle serving the whole route.</p><p>Homestay Po-mu or Ta Xua Lu Tre Homestay. Solo travelers will have an extra charge.</p><p>Meals according to the program: 01 breakfast at the homestay (according to the program), 03 main meals.</p><p>Tickets to visit 1 time at the attractions according to the program.</p><p>01 experienced tour guide, enthusiastic service throughout the route</p><p>Travel insurance pays up to 100,000,000 VND/person/incident</p><p>Health insurance including Covid disease with maximum compensation of 10,000,000 VND/person</p><p>Hanoitourist hat + 01 bottle of mineral water/guest/day</p><p>Price does not include:</p><p>Personal expenses not included in the program</p><p>Tickets to visit attractions outside the program</p><p>Cost of private room (if any)</p><p>Tipping for guides and drivers.</p><p>The cost of testing covid 730,000 VND/person (depending on the time and requirements of each locality).</p><p>VAT according to State regulations</p><p>Cancellation policy:</p><p>Notes and conditions for safe reception:</p><p>The price for children from 5-11 years old is 70% of the adult tour price. This is an experiential trekking journey, you should consider when bringing children with you.</p><p>If you are a vegetarian, please bring more vegetarian food to ensure your taste.</p><p>Pursuant to Resolution No. 128/NQ-CP dated October 11, 2021 of the Government;</p><p>Pursuant to the provisional guidance document No. 3862/HD-BVHTTDL dated October 18, 2021;</p><p>Hanoitourist accepts guests in the following cases:</p><p>You live in Hanoi, in region 1 and 2.</p><p>You have had 2 full doses of COVID-19 vaccine (or the person has recovered from COVID-19 within 6 months, has a negative test certificate for COVID-19) according to the regulations of the Department of Health.</p><p>If you have just received 1 dose of COVID-19 vaccine, Hanoitourist will base on your medical declaration information within 14 days.</p><p>Bring enough legal identification (ID card or Passport)</p><p>Comply with the &ldquo;5K Message&rdquo;; medical declaration as prescribed or scan QR code.</p><p>Fully comply with the regulations of the National Steering Committee for COVID-19 prevention and control, the Ministry of Health and the rules of tourism business establishments.</p><p>Declare a form of commitment to prevent Covid-19 when going on tour.</p>",
                   SummarySchedule = "HANOI - BAC YEN - TA XUA - CONQUERING THE DRIVERS OF DONGERS - HANOI",
                   Status = 1,
                   CreatedAt = GetRandomDate(DateTime.Now.AddYears(-4), DateTime.Now)
               },
               new Tour()
               {
                   Id = "TOUR_11",
                   DepartureId = "LOCAL_1",
                   DestinationId = "LOCAL_12",
                   TourCategoryId = "TOURC_8",
                   Name = "RUSSIA - THE LAND OF BIRCH",
                   Description = "Beautiful Russia known for its palaces and museums, its wide streets and winding canals, Russia's short history has given its cities a wealth of architectural and architectural treasures. art. Along with world-famous attractions like the Hermitage, St. Isaac's Cathedral and the Mariinsky Theatre, Russia is full of lesser-known attractions, but Russia's beauty is no less fascinating, showcasing both the pomp and luxury of St. Petersburg, as well as the mysterious, tragic genius that has moved many great artists and writers of the city. Still considered the cultural capital of Russia,",
                   Detail = "Coming to this country, you will be immersed in a poetic and romantic landscape. Those are the colors of yellow that fill the road. Besides, are the buildings full of classic, magnificent. Thinking about the scene with the one you love walking on this road is so wonderful.",
                   Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656759447/e2w/photo-1580837119756-563d608dd119_m8cezf.avif , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656590900/e2w/65925_ns2xsr.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656590916/e2w/65928_yt08ln.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656590943/e2w/65935_yainyp.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656590967/e2w/65941_xcjddh.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656590990/e2w/65977_qvg5as.png , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656591009/e2w/98552_f5blhx.png",
                   Duration = 3,
                   Rating = 4.5,
                   Policy = "<p>Price includes:</p><p>Two-way flight ticket Hanoi - St Petersburg / Moscow - Hanoi of Aeroflot airline.</p><p>Airport shuttle and sightseeing in Russia according to the program.</p><p>4* cruise ship moving between cities: 10 nights.</p><p>Accommodation: 10 nights stay on the 4-star standard MS REPIN train (02 people/cabin) with amenities such as separate toilets, separate air conditioners for each room, large windows looking out&hellip;</p><p>Meals according to the program: 03 meals/day at the on-board restaurant with Russian and international dishes with a menu that changes daily</p><p>Drinks during meals: one drink per guest (beer or soft drink or 1 glass of wine) for each meal.</p><p>Sightseeing tickets: including entrance tickets (01 time) at attractions</p><p>English/French/Russian tour guide on board and local guide in each city.</p><p>Russian visa fee</p><p>Drinking water placed in the guest cabin: 01 bottle of water per guest per day. In addition, you can get more hot or cold water for free at the water dispenser located on the boat.</p><p>Programs and activities on board such as Russian singing lessons, dance lessons, Matrioska drawing lessons, etc.</p><p>Cocktails with the captain on the first evening when the ship sails</p><p>Personal Translator Headset System</p><p>Price does not include:</p><p>Passport fee (valid for more than 6 months from the date of departure)</p><p>Elective programs outside of the program are available.</p><p>Drinking water outside the main meal; drinks on board such as wine, beer, cocktails&hellip;; laundry, telephone, and personal expenses outside the program.</p><p>Tip (from 10$/day/pax)</p><p>Surcharge for single room ($450/pax) or Suite room ($800/cabin)</p><p>Excess baggage according to the regulations of the goods</p>",
                   SummarySchedule = "VIETNAM - MOSCOW - UGLICH - GORITSY - KIZHI ISLAND - MANDROGUI - ST.PETERSBURG",
                   Status = 1,
                   CreatedAt = GetRandomDate(DateTime.Now.AddYears(-4), DateTime.Now)
               }
                          //               //new Tour()
                          //               //{
                          //               //    Id = "TOUR_12",
                          //               //    DepartureId = "",
                          //               //    DestinationId = "",
                          //               //    Name = "",
                          //               //    Description = "",
                          //               //    Detail = "",
                          //               //    Thumbnail = "",
                          //               //    Duration = 4,
                          //               //    Rating = 4.5,
                          //               //    Policy = "",
                          //               //    SummarySchedule = "",
                          //               //    Status = 1,
                          //               //    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
                          //               //    UpdatedAt = DateTime.Now,
                          //               //    DeletedAt = DateTime.Now
                          //               //},
                          //               //new Tour()
                          //               //{
                          //               //    Id = "TOUR_13",
                          //               //    DepartureId = "",
                          //               //    DestinationId = "",
                          //               //    Name = "",
                          //               //    Description = "",
                          //               //    Detail = "",
                          //               //    Thumbnail = "",
                          //               //    Duration = 4,
                          //               //    Rating = 4.5,
                          //               //    Policy = "",
                          //               //    SummarySchedule = "",
                          //               //    Status = 1,
                          //               //    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
                          //               //    UpdatedAt = DateTime.Now,
                          //               //    DeletedAt = DateTime.Now
                          //               //},
                          //               //new Tour()
                          //               //{
                          //               //    Id = "TOUR_14",
                          //               //    DepartureId = "",
                          //               //    DestinationId = "",
                          //               //    Name = "",
                          //               //    Description = "",
                          //               //    Detail = "",
                          //               //    Thumbnail = "",
                          //               //    Duration = 4,
                          //               //    Rating = 4.5,
                          //               //    Policy = "",
                          //               //    SummarySchedule = "",
                          //               //    Status = 1,
                          //               //    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
                          //               //    UpdatedAt = DateTime.Now,
                          //               //    DeletedAt = DateTime.Now
                          //               //},
                          //               //new Tour()
                          //               //{
                          //               //    Id = "TOUR_15",
                          //               //    DepartureId = "",
                          //               //    DestinationId = "",
                          //               //    Name = "",
                          //               //    Description = "",
                          //               //    Detail = "",
                          //               //    Thumbnail = "",
                          //               //    Duration = 4,
                          //               //    Rating = 4.5,
                          //               //    Policy = "",
                          //               //    SummarySchedule = "",
                          //               //    Status = 1,
                          //               //    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
                          //               //    UpdatedAt = DateTime.Now,
                          //               //    DeletedAt = DateTime.Now
                          //               //}
                          );

            //            //Chi tiết của tour
            context.TourDetails.AddOrUpdate(x => x.Id,
               new TourDetail()
               {
                   Id = "TOURDT_1",
                   TourId = "TOUR_1",
                   DepartureDay = Convert.ToDateTime("2022-07-09T23:49:58+02:00"),
                   AvailableSeat = 2,
                   Price = 42.5,
                   Discount = 15,
                   CreatedAt = Convert.ToDateTime("2022-06-09T23:49:58+02:00")
               },
               new TourDetail() { Id = "TOURDT_2", Status = 1, TourId = "TOUR_2", DepartureDay = Convert.ToDateTime("2022-09-09T23:49:58+02:00"), AvailableSeat = 20, Price = 193, Discount = 10, CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00") },
               new TourDetail() { Id = "TOURDT_3", Status = 1, TourId = "TOUR_3", DepartureDay = Convert.ToDateTime("2022-11-09T23:49:58+02:00"), AvailableSeat = 25, Price = 266, Discount = 10, CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00") },
               new TourDetail() { Id = "TOURDT_4", Status = 1, TourId = "TOUR_4", DepartureDay = Convert.ToDateTime("2022-10-09T23:49:58+02:00"), AvailableSeat = 25, Price = 3525, Discount = 10, CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00") },
               new TourDetail() { Id = "TOURDT_5", Status = 1, TourId = "TOUR_5", DepartureDay = Convert.ToDateTime("2022-12-09T23:49:58+02:00"), AvailableSeat = 25, Price = 270, Discount = 10, CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00") },
               new TourDetail() { Id = "TOURDT_6", Status = 1, TourId = "TOUR_6", DepartureDay = Convert.ToDateTime("2022-08-09T23:49:58+02:00"), AvailableSeat = 25, Price = 1543, Discount = 10, CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00") },
               new TourDetail()
               {
                   Id = "TOURDT_7",
                   TourId = "TOUR_7",
                   DepartureDay = Convert.ToDateTime("2022-04-09T23:49:58+02:00"),
                   AvailableSeat = 30,
                   Price = 1200,
                   Discount = 15,
                   Status = 1,
                   CreatedAt = Convert.ToDateTime("2022-01-09T23:49:58+02:00")
               },
               new TourDetail()
               {
                   Id = "TOURDT_8",
                   TourId = "TOUR_8",
                   DepartureDay = Convert.ToDateTime("2022-07-09T23:49:58+02:00"),
                   AvailableSeat = 25,
                   Price = 500,
                   Discount = 15,
                   Status = 1,
                   CreatedAt = Convert.ToDateTime("2022-01-09T23:49:58+02:00")
               },
                new TourDetail()
                {
                    Id = "TOURDT_9",
                    TourId = "TOUR_9",
                    DepartureDay = Convert.ToDateTime("2022-09-09T23:49:58+02:00"),
                    AvailableSeat = 20,
                    Price = 120,
                    Discount = 10,
                    Status = 1,
                    CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00")
                },
                new TourDetail()
                {
                    Id = "TOURDT_10",
                    TourId = "TOUR_10",
                    DepartureDay = Convert.ToDateTime("2022-12-09T23:49:58+02:00"),
                    AvailableSeat = 20,
                    Price = 560,
                    Discount = 10,
                    Status = 1,
                    CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00")
                },
                new TourDetail()
                {
                    Id = "TOURDT_11",
                    TourId = "TOUR_11",
                    DepartureDay = Convert.ToDateTime("2022-11-09T23:49:58+02:00"),
                    AvailableSeat = 22,
                    Price = 899,
                    Discount = 10,
                    Status = 1,
                    CreatedAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00")
                }

               );
            //Lịch trình của tour
            context.TourSchedules.AddOrUpdate(x => x.Id,
                 new TourSchedule() { Id = "TOURSD_1", TourId = "TOUR_1", ScheduleOrder = 1, Name = "Day 1", Detail = "<p>Welcome to the land of the Himalayas! Upon your arrival at Tribhuvan International Airport, one of our representatives will warmly welcome you. Then he/she will take you to the respective hotel. Overnight stay at Kathmandu.</p>" },
                 new TourSchedule() { Id = "TOURSD_2", TourId = "TOUR_1", ScheduleOrder = 2, Name = "Day 2", Detail = "<p>Today you will begin your Kathmandu city sightseeing with a visit to UNESCO World Heritage Sites. The places include Kathmandu Durbar Square, Pashupatinath Temple, Swayambhunath, and Boudhanath Stupa.</p><p><strong>Pashupatinath Temple</strong></p><p>Situated at 5kms east of Kathmandu valley, Pashupatinath Temple is one of the holiest places dedicated to Lord Shiva. Set on the bank of the sacred Bagmati river, UNESCO listed it as a world heritage site. During the day of Shivaratri, Hindu pilgrims from the world gather to worship Lord Shiva.</p><p><strong>Swayambhunath (Monkey) Temple</strong></p><p>Lies 4kms away from Kathmandu Valley, Swayambhunath temple is one of the holiest shrines for the Buddhist culture in Nepal. Stands on a lovely little hills, this temple offers the picturesque view of the Kathmandu Valley along with majestic Himalayan range.</p><p><strong>Boudhanath Stupa</strong></p><p>Situated 8kms east of Kathmandu valley, Boudhanath is one of the largest stupas in the valley. Tibetan style of Buddhist stupa looms 36 meters high. You can witness the devotees walking around the Stupa as it is the center of Tibetan Buddhism in Nepal.</p><p><strong>Kathmandu Durbar Square</strong></p><p>Kathmandu Durbar Square also known as Hanuman Dhoka is one of the imposing landmarks in Kathmandu valley. Located at the hear of Kathmandu city it is surrounded by both Hindu and Buddhist temple. The major attractions of this landmark are Kumari (Living Goddess) Ghar, Shiva Parvati Temple, Bhagwati Temple, Kal Bhairav Temple, Kasthamandap, Old Palace, and Taleju Temple.</p>" },
                 new TourSchedule() { Id = "TOURSD_3", TourId = "TOUR_1", ScheduleOrder = 3, Name = "Day 3", Detail = "<p>Today you can do some last minute shopping for your closed ones. One of our representatives will drop you to the International airport to catch the flight back to your home.</p>" },
                 new TourSchedule() { Id = "TOURSD_4", TourId = "TOUR_2", ScheduleOrder = 1, Name = "Day 1", Detail = "<p>Morning: The company&apos;s car and tour guide pick you up at the meeting point and transfer you to Noi Bai airport for Vietjet flight VJ505 to Da Nang at 07:55.</p><p><br></p><p>Arriving at Da Nang airport, the car picks up the delegation and departs for you to depart for Non Nuoc Ngu Hanh Son</p><p><br></p><p>Lunch at the restaurant. After that, the group returned to the hotel to check in and rest.</p><p><br></p><p>Afternoon: You depart to visit Son Tra Peninsula (Monkey Mountain) to enjoy the panoramic view of Da Nang coastal city from above, along the Southeast mountainside to admire the beautiful beauty of Da Nang beach, visit Linh Ung Tu - the place with the highest 65m Buddha statue in Vietnam.</p><p><br></p><p>&nbsp;You are free to swim in Da Nang beach.</p><p><br></p><p>Evening: Have dinner at the restaurant, you are free to experience the feeling of Sun Wheel - Top 10 highest wheels in the world, admire the beauty of Da Thanh at night (expenses excluded)</p><p><br></p><p>Overnight at beach hotel</p>" },
                 new TourSchedule() { Id = "TOURSD_5", TourId = "TOUR_2", ScheduleOrder = 2, Name = "Day 2", Detail = "<p><strong>06h30</strong> Ăn s&aacute;ng tại kh&aacute;ch sạn.</p><p><strong>Lựa chọn 1</strong>: (V&eacute; c&aacute;p treo B&agrave; N&agrave; + ăn buffet B&agrave; N&agrave; 970.000 đồng/người &ndash; chi ph&iacute; tự t&uacute;c)<br><strong>Lưu &yacute;: Từ 18/3 &ndash; 24/4, KDL B&agrave; N&agrave; triển khai chương tr&igrave;nh khuyến mại mua v&eacute; c&aacute;p treo tặng v&eacute; buffet trưa.</strong></p><p><strong>07h30</strong> Đo&agrave;n&nbsp;khởi h&agrave;nh đi Khu du lịch B&agrave; N&agrave; - nơi c&oacute; thể kh&aacute;m ph&aacute; những khoảnh khắc giao m&ugrave;a bất ngờ trong một ng&agrave;y. Qu&yacute; kh&aacute;ch tham quan:&nbsp;</p><ul> <li><strong>Đi c&aacute;p treo đạt 2 kỷ lục của th&ecirc;́ giới</strong> - c&aacute;p treo một d&acirc;y d&agrave;i nhất (g&acirc;̀n 6000m) v&agrave; c&oacute; độ cao ch&ecirc;nh lệch giữa ga đi v&agrave; ga đến lớn nhất.&nbsp;</li> <li>Tham quan<strong>&nbsp;khu Le Jardin</strong><strong>&nbsp;</strong>với c&aacute;c di t&iacute;ch của người Ph&aacute;p như:&nbsp;khu buộc ngựa của Ph&aacute;p, c&acirc;y bưởi gần 100 tuổi, vết t&iacute;ch c&aacute;c khu biệt thự cổ.</li> <li>Vi&ecirc;́ng&nbsp;<strong>ch&ugrave;a Linh Ứng</strong> với tượng Phật Th&iacute;ch Ca cao 27m, tham quan Vườn Lộc Uyển, Quan &Acirc;m C&aacute;c.</li> <li>Chinh phục&nbsp;<strong>đỉnh n&uacute;i Ch&uacute;a</strong> ở độ cao 1.487m so với mực nước biển ngắm to&agrave;n cảnh Đ&agrave; Nẵng tr&ecirc;n cao.</li> <li>Tham gia vào các trò chơi tại&nbsp;<strong>Fantasy Park</strong> với&nbsp;c&aacute;c tr&ograve; chơi phi&ecirc;u lưu mới lạ, ngộ nghĩnh, hấp dẫn, hiện đại như v&ograve;ng quay t&igrave;nh y&ecirc;u, Phi c&ocirc;ng Skiver, Đường đua lửa, Xe điện đụng Ng&ocirc;i nh&agrave; ma... &nbsp;</li> <li>Ăn trưa buffet tại nh&agrave; h&agrave;ng</li></ul><p><strong>15h00</strong> Trở về ch&acirc;n n&uacute;i, xe đưa đo&agrave;n trở v&ecirc;̀ nghỉ ngơi và tắm bi&ecirc;̉n.</p><p><strong>Lựa chọn 2</strong>: Qu&yacute; kh&aacute;ch kh&ocirc;ng chọn lựa chọn 1</p><p>Qu&yacute; kh&aacute;ch tự do tắm biển, tham quan th&agrave;nh phố Đ&agrave; Nẵng, tự t&uacute;c ăn trưa</p><p>Ăn tối tại nh&agrave; h&agrave;ng. Buổi tối qu&yacute; kh&aacute;ch tự do kh&aacute;m ph&aacute; th&agrave;nh phố biển về đ&ecirc;m.</p><p>Nghỉ đ&ecirc;m tại kh&aacute;ch sạn mặt biển. &nbsp;</p>" },
                 new TourSchedule() { Id = "TOURSD_6", TourId = "TOUR_2", ScheduleOrder = 3, Name = "Day 3", Detail = "<p>11:30 Have lunch at the restaurant.</p><p><br></p><p>Option 1: (If you go to Vinpearl Nam Hoi An + 700,000 VND/person)</p><p><br></p><p>14h00: Car and guide pick you up and depart for Vinpearl Land Nam Hoi An tourist area so that you have the opportunity to discover and experience Vinpearl River Safari, Vinpearl Land with 20 impressive thrilling games, a majestic water park. garden, indoor play area including 95 video games, 5D cinema room, fairy garden...</p><p><br></p><p>Option 2: If you do not go to Vinpearl Nam Hoi An, you are free to visit.</p><p><br></p><p>17h30 The car takes the group to visit Hoi An ancient town - recognized by UNESCO as a world cultural heritage in December 1999: Hoi An history museum and Quan Cong temple, Phuoc Kien assembly hall, Tan Ky ancient house, Japanese bridge pagoda dinner in Hoi An free to explore the old town at night.</p><p><br></p><p>19h30: Group dinner at the restaurant.</p><p><br></p><p>20h30 - 21h00: The group gathers in the car and guides the group to depart for Da Nang</p><p><br></p><p>Overnight at the beach hotel.</p>" },
                 new TourSchedule() { Id = "TOURSD_7", TourId = "TOUR_2", ScheduleOrder = 4, Name = "Day 4", Detail = "<p>Have breakfast at Hotel.</p><p><br></p><p>The car takes you to visit Wonder Park located at the foot of Thuan Phuoc bridge, this work includes 9 famous wonders of the world and famous works of Vietnam are simulated in miniature such as: Eiffel Tower, Great Wall of China, Statue of Liberty, One Pillar Pagoda,...</p><p><br></p><p>Noon: Have lunch at the restaurant, check out hotel procedures</p><p><br></p><p>Afternoon: The group is free to visit the city, buy Da Nang specialties as gifts, then go to the airport for flight VJ514 at 19:15 to depart for Hanoi.</p><p><br></p><p>Arriving at Noi Bai airport, the car picks you up at the original rendezvous point and bids you farewell. End program.</p>" },
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
                 new TourSchedule()
                 {
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
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_37",
                     TourId = "TOUR_7",
                     ScheduleOrder = 3,
                     Name = "Day 3",
                     Detail = "<p>A city located in the central province of Sri Lanka, Dambulla, is the most famous spice producer in the country. Dambulla is known for the largest temple caves in the country, especially Sigiriya - the lion stone is one of the 8 wonders of the world.</p><p><br></p><p>Morning: Have breakfast at the hotel.</p><p><br></p><p>You depart to SIGIRIYA - Sigiriya is an ancient city ruins and stone fortress is a destination that many people love. This place does not have sparkling high-rise buildings or romantic and poetic rivers. However, Sigiriya still attracts people by natural things that are mixed with wild and majestic. In particular, the Lion Rock Mountain - a delicate beauty located in the middle of a vast and vast forest. You will discover the remains of Sri Lanka&apos;s ancient flourishing. Admiring the beauty of Lion Rock, you will discover the quintessence of architectural art located on the top of the mountain. Among them are many cultural heritages recognized by UNESCO in 1982 and has become an important &quot;cultural triangle&quot; of Sri Lanka.</p><p><br></p><p>After visiting and taking pictures of the area outside Lion Rock, visitors can climb the steps to reach the top of the fortress with an altitude of more than 200 meters above the surrounding area. Visitors will visit and enjoy the frescoes painted with pigments taken from the earth with techniques dating back to the Gupta period discovered in the Ajanta caves - India. Looking down from above, you are standing on the 8th wonder of the world and admire the vast and vast natural beauty. Surely this will be the most memorable experience in your travels.</p><p><br></p><p>Have lunch</p><p><br></p><p>As the central city of Sri Lanka and 116 km from Colombo, Kandy was the last capital of the ancient kings. Kandy is famous for its specialty tea because it is surrounded by rolling tea hills. In addition, Kandy is also a pilgrimage center for domestic and foreign Buddhist followers for spiritual tourism.</p><p><br></p><p>You depart to KANDY on the way to visit the Spice Garden, which includes many famous flavors and spices in Sri Lanka. You will learn about cloves, cardamom, nutmeg, mace and pepper, and many other interesting spices such as chocolate, vanilla, all pure, of course.</p><p><br></p><p>Arriving in Kandy, you visit the Buddha Tooth Relic Temple - the temple is located in the royal palace complex, where the tooth relic of the Buddha is kept. The temple was recognized by UNESCO as a world heritage site in 1988. Located on the romantic Kandy lake, visiting the pagoda allows visitors to feel the soul of this land of Buddha. This is considered the most sacred and revered place of the Sri Lankan Buddhist community and the world. You visit and record souvenir photos by the poetic Kandy Lake. Visit the Sri Lankan Gems &amp; Gems Museum.</p><p><br></p><p>Have dinner at the restaurant. If time allows, you have the opportunity to enjoy a special art performance.</p><p><br></p><p>Overnight at Cinnamon Citadel Hotel 4**** or similar in Kandy.</p><p><br></p><p>Overnight in Kandy</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_38",
                     TourId = "TOUR_7",
                     ScheduleOrder = 4,
                     Name = "Day 4",
                     Detail = "Morning: After breakfast, depart for Nuwara Eliya, which is known as the 'City of Light'. Along the way, the group will visit:Peradeniya Royal Botanical Gardens: is a famous botanical garden in Sri Lanka and one of the most typical gardens in Asia.Tea plantation and factory where the best tea in the world is produced: You can witness the tea production process and enjoy cups of pure Ceylon tea in the factory. It is also the heart of the country famous for its teas, which produces a large number of the world's finest teas.Have lunch at restaurantAfternoon: You visit 'Nuwara Eliya Celestial Realm' - After the British found Nuwara Eliya lying in the hills in Central Sri Lanka, they found that they had discovered a real paradise. Nuwara Eliya is a great destination for travelers who want to have a memorable vacation. The name Nuwara Eliya has two meanings, that is 'city on the plateau' and 'city of light', located at an altitude of 1,868m above sea level, Nuwara Eliya is not a big city. Tourists can walk to visit all the interesting destinations in the inner city. This place still retains the romance of an old city in the early 20th century, with narrow streets and rows of tube houses close together with British colonial buildings such as town hall and post office. central power... The hilly soil and temperate climate make it the center of Sri Lanka's tea growing. The teas exported around the world come from here.Nuwara Eliya's two most precious 'gifts' are beauty and tranquility. Visitors will admire the richness of nature, while washing themselves in the fresh air of the mountain city. Heaven is not far away, it is here.Evening: Have dinner at the restaurant.You stay overnight at Araliya Red Hotel 4**** in Nuwara Eliya.Overnight in Elijah."
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_39",
                     TourId = "TOUR_7",
                     ScheduleOrder = 5,
                     Name = "Day 5",
                     Detail = "<p>Morning: Have breakfast at the hotel.</p><p><br></p><p>You depart back to Colombo. You stop by Kitulgala: The place where the famous movie &quot;Bridge over the River Kwai&quot; was made - one of the greatest historical films of all time, the film won the Oscar in 1957. See St. Clair&apos;s waterfall and Devon waterfall.</p><p><br></p><p>Noon: Have lunch at the restaurant</p><p><br></p><p>Afternoon: You visit Colombo city - the capital and largest city of Sri Lanka.</p><p><br></p><p>You visit Gangamaya temple - is the largest temple in Colombo dating back 120 years.</p><p><br></p><p>The car takes you through the places of the city: Hindu temple, Jumma Alfar Jumi-UL mosque; Dutch Church; Hultsdorf Law Court, Cinnamon Gardens residential area; Fort commercial area: Formerly built by Portuguese and Dutch colonists, Independence Square; ceramics showroom; shopping complex.</p><p><br></p><p>You explore the daily life of the people, shop for typical Sri Lankan products at extremely low prices.</p><p><br></p><p>Evening: Have dinner at the restaurant.</p><p><br></p><p>The car takes you to the airport for flight procedures to Vietnam.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_40",
                     TourId = "TOUR_7",
                     ScheduleOrder = 6,
                     Name = "Day 6",
                     Detail = "<p>You check in for flight SQ 469 to Singapore (00h50 - 07h20).</p><p><br></p><p>Return to Hanoi: Connect to flight SQ 192 (09:15 - 11:25). 11:25 am landing at Noi Bai airport, the car will take you to the original pick-up point, the tour guide bids farewell and ends the program. See you again in the following programs.</p><p>You return to Ho Chi Minh City: Connect to flight SQ 178 (09:45 - 10:55). 10:55am landed at Tan Son Nhat airport. Say goodbye to customers and end the program, see you in the following programs.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_41",
                     TourId = "TOUR_8",
                     ScheduleOrder = 1,
                     Name = "Day 1",
                     Detail = "<p>05:30 Car and tour guide of Hanoitourist Travel Company will pick you up at the meeting point to depart for Cat Ba - an ideal rendezvous in hot summer days with beautiful beaches and special ecological national forests. sharp. 08:30 Arrive at Binh wharf, board the speedboat to Cat Ba. Have lunch, check in hotel and rest. Afternoon: you are free to swim at Cat Co beach. Have dinner. Overnight at the hotel</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_42",
                     TourId = "TOUR_8",
                     ScheduleOrder = 2,
                     Name = "Day 2",
                     Detail = "<p>Have breakfast. The car takes the group to visit Cat Ba National Forest, climb to explore Kim Giao forest, visit Trung Trang Cave - 200m long located on the mountainside with many stalactites of different shapes sparkling like jewels. Return to the hotel, have lunch and check out of the hotel.</p><p><br></p><p>12:00 Transfer to Gia Luan wharf, board a boat to visit Ha Long Bay with 1969 large and small islands, explore Thien Cung cave with countless stalactites sparkling under colored lights, as magnificent as a palace. electricity, admire the fighting cock stone, the stone dog, the incense peak.</p><p><br></p><p>17:00 The boat arrives at the wharf, the car picks up the group and takes it to the hotel to check in</p><p><br></p><p>18:00 Pick up the delegation to dinner and to Tuan Chau island, you visit and watch dolphin shows or water music (own expense).</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_43",
                     TourId = "TOUR_8",
                     ScheduleOrder = 3,
                     Name = "Day 3",
                     Detail = "<p>Have breakfast. You are free to rest or go to the market to shop for seafood. 11:30 Delegation check out and have lunch at the restaurant.</p><p><br></p><p>14:00 The car takes the group back to Hanoi, on the way stops at Hai Duong, you enjoy and shop for local specialties: mung bean cake, gai cake... Go to the initial pick-up point, say goodbye to you. End program</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_44",
                     TourId = "TOUR_9",
                     ScheduleOrder = 1,
                     Name = "Day 1",
                     Detail = "<p>07h00 Car and guide of Hanoitourist pick up the group at 18 Ly Thuong Kiet and depart for the trip to visit Duong Lam Ancient Village.</p><p><br></p><p>08h30: Arrive at Duong Lam Ancient Village, start a walking journey to learn about the unique ancient Vietnamese village in the cultural space of Doai, where two famous kings were born in the history of the Vietnamese nation.</p><p><br></p><p>Take souvenir photos at Banyan Tree and Village Gate - one of the most famous traditional Vietnamese village gates in the country.</p><p>Visit Mong Phu communal house over 400 years old, Tham Hoa church of Giang Van Minh and one of the old houses - where you can see and take pictures with the ancient rice mill, buy soy sauce, buy lam tea.</p><p>Visit Mia Pagoda, a temple built by Princess Mia in the 17th century. In the present temple, there are 287 statues, with a unique architecture, very rich and lively.</p><p>12h00 You enjoy lunch in a traditional house made of wood and laterite. After lunch you take a rest.</p><p><br></p><p>13h30 You continue to visit:</p><p><br></p><p>Temple, Tomb of Ngo Quyen and Temple of the Great King Phung Hung - the place to worship two famous kings in the history of the Vietnamese nation</p><p>Explore the famous thousand-year-old Duoi Range in Duong Lam. According to legend, this is the place where Ngo Quyen tied elephants and war horses after exercises with the insurgent army to prepare to move to the Bach Dang estuary to fight the Southern Han army.</p><p>15h00 Delegation to visit Va Temple, also known as Dong Cung, located in Van Gia village, Trung Hung ward, one of the four palaces of Doai, worshiping Tan Vien Son Thanh - the leading god in the &quot;Four Immortals&quot; of Vietnam. Vietnamese folk beliefs</p><p><br></p><p>16h00 You get on the bus back to Hanoi.</p><p><br></p><p>18h00 The group returned to the original point. Goodbye everyone, the programs is ended here.</p><p>07h00 Car and guide of Hanoitourist pick up the group at 18 Ly Thuong Kiet and depart for the trip to visit Duong Lam Ancient Village.</p><p><br></p><p>08h30: Arrive at Duong Lam Ancient Village, start a walking journey to learn about the unique ancient Vietnamese village in the cultural space of Doai, where two famous kings were born in the history of the Vietnamese nation.</p><p><br></p><p>Take souvenir photos at Banyan Tree and Village Gate - one of the most famous traditional Vietnamese village gates in the country.</p><p>Visit Mong Phu communal house over 400 years old, Tham Hoa church of Giang Van Minh and one of the old houses - where you can see and take pictures with the ancient rice mill, buy soy sauce, buy lam tea.</p><p>Visit Mia Pagoda, a temple built by Princess Mia in the 17th century. In the present temple, there are 287 statues, with a unique architecture, very rich and lively.</p><p>12h00 You enjoy lunch in a traditional house made of wood and laterite. After lunch you take a rest.</p><p><br></p><p>13h30 You continue to visit:</p><p><br></p><p>Temple, Tomb of Ngo Quyen and Temple of the Great King Phung Hung - the place to worship two famous kings in the history of the Vietnamese nation</p><p>Explore the famous thousand-year-old Duoi Range in Duong Lam. According to legend, this is the place where Ngo Quyen tied elephants and war horses after exercises with the insurgent army to prepare to move to the Bach Dang estuary to fight the Southern Han army.</p><p>15h00 Delegation to visit Va Temple, also known as Dong Cung, located in Van Gia village, Trung Hung ward, one of the four palaces of Doai, worshiping Tan Vien Son Thanh - the leading god in the &quot;Four Immortals&quot; of Vietnam. Vietnamese folk beliefs</p><p><br></p><p>16h00 You get on the bus back to Hanoi.</p><p><br></p><p>18h00 The group returned to the original point. Goodbye everyone, the programs is ended here.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_45",
                     TourId = "TOUR_10",
                     ScheduleOrder = 1,
                     Name = "Day 1",
                     Detail = "<p>6h00: Car and tour guide Hanoitourist pick you up at Hanoitourist 18 Ly Thuong Kiet, depart for Ta Xua. The delegation stopped at 1 point on the way and had breakfast (self-sufficient). Then continue the journey to discover the white cloud paradise - Ta Xua.</p><p><br></p><p>12h00: The group stops for lunch at Nha San restaurant.</p><p><br></p><p>After lunch, check-in homestay.</p><p><br></p><p>14h00: Travel to a hundred-year-old tea village, green steppe in the middle of the forest. Amidst rolling hills and mountains, Ta Xua appears a vast, green steppe like in the middle of Europe in the clouds.</p><p><br></p><p>Continuing to go to the end of the steppe, you will encounter the jade-green Lang Sang river, which is compared to the legendary Nho Que stream of Ha Giang.</p><p><br></p><p>Through the steppe, move down to the dolphin&apos;s ridge and the lonely tree with million views near the hydroelectric lake. The location of the lonely tree is compared to the intersection between the lonely tree in Da Lat and the Nho Que river along with the majestic mountains of Ha Giang. You will have unique photos here when you catch the sunset in Ta Xua and see the majestic mountains and clouds.</p><p><br></p><p>17h30: Be at the Homestay, prepare to welcome the most beautiful sunset in the world right at the homestay.</p><p><br></p><p>Group dinner at homestay.</p><p><br></p><p>If you are an astronomy enthusiast, this is the most ideal spot for you to see Milky. If it&apos;s a clear night with a full moon, you&apos;ll see Hang up close and bright. If you are lucky enough, it will be a surreal beautiful night with a bright moon above white clouds.</p><p><br></p><p>Overnight in Ta Xua.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_46",
                     TourId = "TOUR_10",
                     ScheduleOrder = 2,
                     Name = "Day 2",
                     Detail = "<p>Morning: Get up early in the morning, prepare to hunt clouds to welcome the beautiful sunrise on Ta Xua peak right at the homestay. If it is a beautiful morning and meets Van, it will be a white cloud paradise, a beautiful cloud paradise. Take a photo tour around the house.</p><p><br></p><p>Have breakfast.</p><p><br></p><p>8:30am: Conquer the spines of dinosaurs, listen to ethnic music and go to the village to enjoy coffee and see Ta Xua mountain.</p><p><br></p><p>12h00: Return to homestay, check out procedures. Then the car took the group to have lunch at Ta Xua restaurant.</p><p><br></p><p>13h30: Move back to Hanoi.</p><p><br></p><p>Farewell to you. End of the cloud hunting tour program in Ta Xua. Hope to see you again in your next journey.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_47",
                     TourId = "TOUR_11",
                     ScheduleOrder = 1,
                     Name = "Day 1",
                     Detail = "<p>06h30 You gather at Hanoi Opera House, car and guide pick up the delegation to Noi Bai international airport for procedures for flight SU 291 Hanoi - Moscow 10h05-16h05.</p><p>Delegation to Moscow&apos;s international airport, do immigration and customs procedures.</p><p><br></p><p>Tour guide and car will pick you up at the airport and transfer you to the MS REPIN 4* train.</p><p><br></p><p>Check in. Have dinner and overnight on board.</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_48",
                     TourId = "TOUR_11",
                     ScheduleOrder = 2,
                     Name = "Day 2",
                     Detail = "<p>After breakfast on board, the bus will pick you up at the port to visit Moscow:</p><p><br></p><p>Leningradsky Avenue.</p><p>Tverskaya street.</p><p>GUM National Department Store.</p><p>Kazan Church.</p><p>Christ the Saviour Cathedral with its gilded dome is the largest and tallest Orthodox church in the world.</p><p>Lunch.</p><p><br></p><p>Afternoon visit:</p><p><br></p><p>Kremlin - one of the city&apos;s oldest massive building complexes overlooking Red Square, since 1995 it has become an open-air museum and welcomes tourists, Red Square, Lenin&apos;s Mausoleum , Aleksandre Garden, Church of Vasily Blazhenui.</p><p>In the afternoon, the car picks up the group back to the ship for dinner and overnight</p>"
                 },
                 new TourSchedule()
                 {
                     Id = "TOURSD_49",
                     TourId = "TOUR_11",
                     ScheduleOrder = 3,
                     Name = "Day 3",
                     Detail = "<p>08h:20 you arrive at Noi Bai airport, do immigration procedures, receive luggage. The car will pick you up at the original meeting point. Farewell to you and see you again in the next journey.</p>"
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
            // Mẫu xe
            context.CarModels.AddOrUpdate(x => x.Id,
                new CarModel() { Id = "CARMD_1", CarBrandId = "CARBR_1", Name = "Honda City" },
                new CarModel() { Id = "CARMD_2", CarBrandId = "CARBR_2", Name = "Camry 2.0" },
                new CarModel() { Id = "CARMD_3", CarBrandId = "CARBR_3", Name = "Maybach s600" },
                new CarModel() { Id = "CARMD_4", CarBrandId = "CARBR_4", Name = "Kia Cerato " },
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
                new CarType() { Id = "CARTP_7", Name = "Roadster" }
                );
            //Xe
            context.Cars.AddOrUpdate(x => x.Id,
                new Car()
                {
                    Id = "CAR_1",
                    CarModelId = "CARMD_1",
                    CarTypeId = "CARTP_1",
                    LocationId = "LOCAL_1",
                    Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656674281/e2w/ha-noi-ban-xe-honda-city-1-5l-at-2014-480p-xocLoq5sPeRFNsY5F_bjetce.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656674289/e2w/ha-noi-ban-xe-honda-city-1-5l-at-2014-480p-c7vhYDfsyE4WMFL34_gxiad1.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656674299/e2w/ha-noi-ban-xe-honda-city-1-5l-at-2014-480p-RpQhfm3CmMoagEFnW_ogdycv.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656674316/e2w/ha-noi-ban-xe-honda-city-1-5l-at-2014-480p-kznmr3eJje8jJWkPC_octka6.jpg",
                    LisencePlate = "30-A-333.86",
                    HasAirConditioner = true,
                    SeatCapacity = 5,
                    PricePerDay = 43,
                    Status = 1,
                    HasDriver = true,
                    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
                    Description = "The Honda City is a small City hatchback with a slightly unique design, which Honda calls the 'Tall Boy' style.",
                    Rating = 4.5
                },
                new Car()
                {
                    Id = "CAR_2",
                    CarModelId = "CARMD_2",
                    CarTypeId = "CARTP_5",
                    LocationId = "LOCAL_1",
                    Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656674611/e2w/ha-noi-ban-xe-toyota-camry-2-0-at-2019-480p-8D2vPBHCCkis9xxf2_ak1hgn.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656674616/e2w/ha-noi-ban-xe-toyota-camry-2-0-at-2019-480p-bYK66XKvxFcCh7e7d_wjxxjw.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656674626/e2w/ha-noi-ban-xe-toyota-camry-2-0-at-2019-480p-cNcsfFjD8CaKQ3ma5_rvazxr.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656674632/e2w/ha-noi-ban-xe-toyota-camry-2-0-at-2019-480p-WmNkPykpnrMmmgFzm_eu6llt.jpg",
                    LisencePlate = "30-F-650.34",
                    HasAirConditioner = true,
                    SeatCapacity = 5,
                    HasDriver = true,
                    PricePerDay = 50,
                    Status = 1,
                    CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
                    Description = "Dubbed the 'king of mid-size sedans', Camry has continuously improved over the years to continue to gain the trust and become the first choice of business customers, especially in the business world. a time when many entrepreneurs have achieved success at a very young age.",
                    Rating = 5
                },
                 new Car()
                 {
                     Id = "CAR_3",
                     CarModelId = "CARMD_3",
                     CarTypeId = "CARTP_3",
                     LocationId = "LOCAL_1",
                     Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656675320/e2w/maybach_S600_3_zxtypx.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656675326/e2w/maybach_S600_2_otflhp.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656675331/e2w/maybach_S600_1_azap3m.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656675336/e2w/maybach_S600_4_whw5py.jpg",
                     LisencePlate = "30-A-988.89",
                     HasAirConditioner = true,
                     SeatCapacity = 4,
                     PricePerDay = 1000,
                     Status = 1,
                     HasDriver = true,
                     CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
                     Description = "The 2017 Mercedes Maybach S600 is the most luxurious Mercedes sedan in the Vietnamese market. The exterior and interior of the car are designed to be extremely luxurious, classy and attractive. The ability to operate is extremely strong and safe with a series of the most modern and advanced technologies in the world today.",
                     Rating = 5
                 },
                 new Car()
                 {
                     Id = "CAR_4",
                     CarModelId = "CARMD_2",
                     CarTypeId = "CARTP_1",
                     LocationId = "LOCAL_1",
                     Thumbnail = "https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656676148/e2w/ha-noi-ban-xe-kia-cerato-2-0-at-2016-480p-b6k87jxCa6v6fAgM2_bw4h6t.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656676148/e2w/ha-noi-ban-xe-kia-cerato-2-0-at-2016-480p-b6k87jxCa6v6fAgM2_bw4h6t.jpg ,https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656676157/e2w/ha-noi-ban-xe-kia-cerato-2-0-at-2016-480p-uYpSbu6kQh9Zuag9w_jdk0dv.jpg , https://res.cloudinary.com/dyrfhqz3j/image/upload/v1656676168/e2w/ha-noi-ban-xe-kia-cerato-2-0-at-2016-480p-2H9CyE4Zhqqoi5XGw_wqxkw8.jpg ",
                     LisencePlate = "30-G-757.33",
                     HasAirConditioner = true,
                     SeatCapacity = 5,
                     PricePerDay = 100,
                     HasDriver = false,
                     Status = 1,
                     CreatedAt = Convert.ToDateTime("2021-08-09T23:49:58+02:00"),
                     Description = "On the 2016 version, Cerato/K3 has been redesigned quite a lot at the front and rear of the car to feel more solid and impressive. The front end has been completely redesigned with a new grille, new headlights and a new front bumper. The grille on the 2016 Cerato has a more square shape, the headlights are also designed to fit better with the grille. The 17 dual 5 - spoke rims are similar to those on the current K3.",
                     Rating = 4
                 }
                );




            //Khách sạn
            context.Hotels.AddOrUpdate(x => x.Id,
                new Hotel()
                {
                    Id = "HT_1",
                    Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656753165/hotel/247138462_ijf1xp.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656753222/hotel/235160460_ywciy6.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656753290/hotel/248126446_anfabg.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656753347/hotel/208585792_hnawc5.jpg",
                    Name = "Hanoi Prime Center Hotel",
                    LocationId = "LOCAL_1",
                    Rating = 4,
                    Address = "36 Hang Huong, Quan Hoan Kiem , Ha Noi , Viet Nam",
                    Price = 25,
                    Description = "Hanoi Prime Center Hotel offers rooms with private balconies in the heart of Hanoi.Among the facilities of this property are a restaurant, a 24-hour front desk, room service and free WiFi.The property can arrange private parking for guests at an account surcharge.",
                    Detail = "<p>Offering air-conditioned rooms in the Hoan Kiem district of Hanoi, Hanoi Prime Garden Hotel &amp; Spa is 701 m from Dong Xuan Market. Among the facilities of this property are a restaurant, a 24-hour front desk and room service, along with free WiFi. The hotel features family rooms. At the hotel, each room includes a desk, a flat-screen TV and a private bathroom. All units at Hanoi Prime Garden Hotel &amp; Spa are equipped with a seating area. A continental breakfast is available daily at the accommod.<br /> Address: 36 Hang Huong, Quan Hoan Kiem, Ha Noi, Viet Nam <br /> Phone: (+84) 24 3747 6265 <br /> Hotline: (+84) 913 317 474 <br /> Email: info@hanoiprimecenter.com </ p > ",
                    Status = 1,
                    CreatedAt = Convert.ToDateTime("2017-01-09T23:49:58+02:00")
                },
new Hotel()
{
    Id = "HT_2",
    Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656754601/hotel/221822290_uqgxhy.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656754601/hotel/224642213_fq0z0f.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656754601/hotel/221824600_xubwji.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656754600/hotel/221823621_uxdq3v.jpg",
    Name = "The Oriental Jade Hotel",
    LocationId = "LOCAL_1",
    Rating = 5,
    Address = "92 - 94 Hang Trong, Quan Hoan Kiem, Viet Nam",
    Price = 40,
    Description = "Reimagine the timeless glamour of travel in Hanoi Old quarter. Building on its long history as a global beacon of hospitality, offering a blend of the best Eastern and Western hospitality in an atmosphere of unmatched classical grandeur and timeless elegance.",
    Detail = "<p>The Oriental Jade Hotel &ndash; a member of Oriental Hospitality Group (OHG) - offers 120 premium guest rooms and suites with stunning views of Hoan Kiem Lake, Hanoi Cathedral and Hanoi Old Quarter. Located on Hang Trong Street, the hotel provides guests with a convenient base from which they can explore Hanoi Old Quarter within walking distance. Staying at The Oriental Jade Hotel, guests can relax at O’Spa Lotus where locally - inspired treatments provide the ultimate relaxation. For guests who want to stay fit on the go, our state - of - the - art gym facilities and outdoor pool on the 12th floor allow them to exercise in style with a stunning view of Hanoi Old Quarter.For dining options, Thang Long Signature restaurant offers a wide range of Vietnamese and Western cuisine that promises to impress your taste buds at the first bite. Guests can also chill out at our Sixteen Sky Bar, taking a sip of our signature cocktails while enjoying a mesmerizing view of the Sword Lake. At The Oriental Jade Hotel, customer satisfaction remains our top priority. We are committed to delivering bespoke services that go beyond guests&rsquo; expectations. Let us bring you a memorable stay in Hanoi!<br />Address: No. 92-94 Hang Trong Street, Hoan Kiem District, Hanoi, Vietnam<br />Phone: (+84) 24 3936 7777<br />Hotline: (+84) 942 217 271<br />Email: sales@theorientaljadehotel.com</p>",
    Status = 1,
    CreatedAt = Convert.ToDateTime("2017-02-09T23:49:58+02:00")
},
new Hotel()
{
    Id = "HT_3",
    Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656755534/hotel/354844000_tg45ye.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656755534/hotel/354843965_ixrtti.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656755534/hotel/241636339_qmxjbo.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656755534/hotel/273906460_du8ejw.jpg",
    Name = "Peridot Grand Luxury Boutique Hotel",
    LocationId = "LOCAL_1",
    Rating = 5,
    Address = "33 Duong Thanh, Quan Hoan Kiem, Ha Noi, Viet Nam",
    Price = 45,
    Description = "Pamper yourselves with 105 well-furnished rooms and suites beautifully finished with contemporary touches and elegant artwork. Arrays of restaurants and bars, an infinity swimming pool, a state-of-the-art gym.",
    Detail = "<p>Fusing comfort with artistic design, our light flooded, city view suite features an en-suite bathroom, separate living room and a wide range of in-room entertainment options. Enjoy a relaxing soak, complete with luxurious bath amenities in the stylish marble bathroom at this preferred hotel suite. We integrate local spa rituals with indigenous ingredients, a profoundly therapeutic touch, and a gentle sense of joy and discovery. The festive packages at the Peridot Grand Luxury Boutique Hotel have been put together to ensure you have plenty of time to relax and unwind. On this opening occasion, OLIVINE Restaurant &amp; Bar is offering discounted vouchers for lunch &amp; dinner (not applied for drinks) for all in-house guestsOur luxury suite allow you plenty of room to relax and unwind.Enjoy a relaxing soak,complete with luxurious bath amenities in the stylish marble bathroom at this preferred suite.<br /> Address: 33 Duong Thanh street,Hoan Kiem district,Hanoi,Vietnam <br /> Phone: (+84) 24 3828 0099 <br /> Hotline: (+84) 886 428 888 <br /> Email: info.grand@peridothotels.com </ p > ",
    Status = 1,
    CreatedAt = Convert.ToDateTime("2017-03-09T23:49:58+02:00")
},
new Hotel()
{
    Id = "HT_4",
    Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656756534/hotel/279946906_wtv6k5.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656756534/hotel/151687976_wiwm8q.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656756535/hotel/122578512_nssiyn.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656756534/hotel/122666741_l8ppo9.jpg",
    Name = "Pullman HaNoi",
    LocationId = "LOCAL_1",
    Rating = 5,
    Address = "41 Cat Linh, Quan Dong Da, Ha Noi, Viet Nam",
    Price = 42,
    Description = "Pullman Hanoi offers hospitality in the heart of the bustling metropolis. A place to enjoy life, not just a place to rest. You can also get a Pullman Hanoi of the life of the big time in the busiest schedule.",
    Detail = "<p>It is a perfect place to relax near the meeting room, allowing event organizers or participants to relax comfortably during breaks and after each meeting. Weddings, anniversaries, fashion shows &ndash; whatever the event, Pullman Hanoi's Event Manager can help you organize it to the fullest. With an area of ​​580 m2, equipped with standard sound and light systems, high-speed internet, the banquet hall of the Temple of Literature is always ready for big events. Luxurious and modern. Mint Bar always brings smart and responsive service style. A place to socialize, work and relax. There are many reasons to experience here. Try starting out with a sip of a wine from the Vinoteca by Pullman wine list selected specifically for the Pullman brand. With an exquisite menu of tapas snacks and main courses, Mint Bar will be the perfect place to meet friends. With an outdoor swimming pool with a sun - drenched patio, and a refreshing cocktail, Pullman Hanoi knows that you work hard and deserve to play hard.<br />Address: 40 Cat Linh street (Entrance 61 Giang Vo street), Dong Da district, 10000 Hanoi, Vietnam<br />Phone: (+84) 24 3733 0688<br />Hotline: (+84) 2437 330 888<br />Email: H7579@accor.com</p>",
    Status = 1,
    CreatedAt = Convert.ToDateTime("2017-04-09T23:49:58+02:00")
},
new Hotel()
{
    Id = "HT_5",
    Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656757316/hotel/352170974_cnpgah.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656757316/hotel/211875103_xdz4vj.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656757316/hotel/222768542_kqpcom.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656757316/hotel/349674629_b9esev.jpg",
    Name = "Nagila Boutique Hotel",
    LocationId = "LOCAL_5",
    Rating = 4,
    Address = "Lo 11-12 Khu H1, P. An Hai Bac, Quan Son Tra, Da Nang, Viet Nam",
    Price = 38,
    Description = "The car parking and the Wi-Fi are always free, so you can stay in touch and come and go as you please. Conveniently situated in the Phuoc My part of Da Nang, this property puts you close to attractions and interesting dining options.",

    Detail = "<p>This site is how to the beach 14 min walk. Enjoying a prime location in the My Khe Beach district of Da Nang, Nagila Boutique Hotel features a restaurant, operating records, fitness center and bar. This hotel has a shared hotel as well as a hammam. The property offers a 24-hour front desk, a service room and currency exchange for guests. Each room at Nagila Boutique Hotel comes with air conditioning, a seating area, a satellite TV, a safe and a private bathroom with a shower/toilet, bathrobes and slippers. Rooms are equipped with linens and towels. Costumes serve continental breakfast or buffet dinner. Nagila Boutique Hotel has a terrace. Popular points of interest of the hotel include My Khe Beach, Song Han Bridge and Indochina Riverside Mall. The nearest airport is Da Nang International Airport, 7 km from Nagila Boutique Hotel, and the property offers an airport shuttle service at a surcharge.<br />Address: Lo 11-12 Khu H1, P. An Hai Bac, Quan Son Tra, Da Nang, Viet Nam<br />Phone: (+84) 23 6327 2777<br />Hotline: (+84) 816 527 777<br />Email: sales1@nagilahotel.com</p>",
    Status = 1,
    CreatedAt = Convert.ToDateTime("2017-05-09T23:49:58+02:00")
},
new Hotel()
{
    Id = "HT_6",
    Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656758061/hotel/268639745_axc71a.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656758061/hotel/276733912_c15cpu.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656758060/hotel/268639759_ivlcho.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656758060/hotel/268639766_gilkfd.jpg",
    Name = "Abogo Resort Villas Beachview Da Nang",
    LocationId = "LOCAL_5",
    Rating = 5,
    Address = "05 Truong Sa, Da Nang, Viet Nam",
    Price = 60,
    Description = "Abogo is a joint stock company with a multi-industry-multinational corporation registered with a license in Vietnam. Owner and operator of all 5 Star Seaside Villa Resort systems in Da Nang and nationwide.",
    Detail = "<p>The property is a 1-minute walk from the beach. Featuring river views, Abogo Resort Villas Beachview Da Nang is located in Da Nang and has a restaurant, 24-hour front desk, bar, garden, year-round outdoor swimming pool and children's playground. The villa offers free WiFi and private parking. Each unit has lake/pool views, a kitchen, a flat-screen TV with satellite channels and a Blu-ray player, a work desk, a washing machine, and a private bathroom with a hot tub and bathrobes. shower. All units are equipped with air conditioning as well as a seating and/or dining area. Abogo Resort Villas Beachview serves a daily continental breakfast. Guests can make use of the spa and wellness center, play billiards, arrange trips at the tour desk, or rent a car to explore the surroundings. The property features a gym and laundry facilities. Skiing and cycling can be enjoyed nearby, while ski equipment rentals, a private beach area and a ski pass are also available on site. Popular points of interest near Abogo Resort Villas Beachview Da Nang include Non Nuoc Beach, Bac My An Beach and Marble Mountains. The nearest airport is Da Nang International Airport, 8 km from the villa, and the property offers a free airport shuttle service.<br />Address: 05 Truong Sa, Da Nang, Viet Nam<br />Phone: (+84) 93 4541 444<br />Hotline: (+84) 943 439 585<br />Email: info@abogovillas.com</p>",
    Status = 1,
    CreatedAt = Convert.ToDateTime("2017-06-09T23:49:58+02:00")
},
new Hotel()
{
    Id = "HT_7",
    Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656758764/hotel/365398250_ez3jgf.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656758763/hotel/222745555_wnr93j.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656758764/hotel/365398468_ez5ut2.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656758763/hotel/365398381_pt2bzp.jpg",
    Name = "Mon Cheri Cruises",
    LocationId = "LOCAL_10",
    Rating = 5,
    Address = "Got Pier, Cat Hai, Ha Long, Viet Nam",
    Price = 48,
    Description = "It is a Perfect blend of the Sophistication between the Classic European form and the rustic essence of Vietnamese Styling. Mon Chéri Cruises itself creates the difference with the tiny distinguished.",
    Detail = "<p>Set in Ha Long, 2.7 km from Tuan Chau Harbor and 15 km from Queen Cable Car, Mon Cheri 2 Cruise features a restaurant, fitness centre, toolbar and free WiFi. This site rest also features a service room and a children's playground. This yacht offers family rooms. Air-conditioned rooms at Mon Cheri Cruises 2 include a work desk, water temperature, a refrigerator, a minibar, a safety deposit box, a flat-screen TV, a balcony and a private bathroom with a shower. All rooms are equipped with linens and towels. Costumes serve continental breakfast or buffet dinner. Mon Cheri Cruises 2 features a terrace. Cruise guests will be able to enjoy activities in and around Ha Long, like fishing. Mon Cheri Cruises 2 is 21 km from Vincom Plaza Ha Long and 23 km from Quang Ninh Museum. The nearest airport is Cat Bi International Airport, 69 km from the property. This site's special couples - they give it a 10 for a stay for 2. Mon Cheri Cruises has been welcoming Booking.com guests since Apr 3, 2019.The property offers a continental breakfast or a buffet breakfast. Mon Cheri Cruises 2 features a terrace. Cruise guests can enjoy activities in and around Ha Long, like fishing. Mon Cheri Cruises 2 is 21 km from Vincom Plaza Ha Long and 23 km from Quang Ninh Museum. The nearest airport is Cat Bi International Airport, 69 km from the property.<br />Address: Got Pier, Cat Hai, Ha Long city, Vietnam<br />Phone: (+84) 24 3933 5728<br />Hotline: (+84) 984 749 958<br />Email: info@monchericruises.com</p>",
    Status = 1,
    CreatedAt = Convert.ToDateTime("2017-07-09T23:49:58+02:00")
},
new Hotel()
{
    Id = "HT_8",
    Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656759342/hotel/261526548_imsxz7.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656759342/hotel/261525833_na0kew.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656759342/hotel/261526457_uxxwvv.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656759342/hotel/261526473_fnenyg.jpg",
    Name = "Lapinta Cruise Lan Ha Bay",
    LocationId = "LOCAL_10",
    Rating = 5,
    Address = "Got Pier, Ha Long, Viet Nam",
    Price = 44,
    Description = "La Pinta Cruise is one of the most luxurious 5- star cruises of Halong Bay – Lan Ha Bay – symbol of the nature beauty in Vietnam. The cruise has 16 spacious cabins with private balcony bound to the spectacular view of Lan Ha Bay.",
    Detail = "<p>La Pinta Cruises are the finest mid-size cruise ships on the sea route of Halong Bay &ndash; Lan Ha Bay &ndash; symbol of the nature beauty in Vietnam. Our cruises has 16 spacious cabins with private balcony bound to the spectacular view of Lan Ha Bay and emerald ocean, ample deck and well-equipped interior and it possibly owns the top customer services. La Pinta aims at an ultimate leisure, perfect for couples and families to explore Lan Ha Bay, and to discover areas covered within the World Heritage Halong Bay ensemble. La Pinta Cruises provides our guests an exceptional and tailored itinerary that offers a second to none experience on the above route. Mission of La Pinta is creating a peace of mind state for our dear Customers wellbeing. With an elite, professional crew we do hope our tourists will have an enjoyable and memorable trip with La Pinta. Anchored in Ha Long City, 3.6 km from Tuan Chau International Pier, Lapinta Cruise Lan Ha Bay features express check-in and check-out, app-free rooms, a restaurant, and free WiFi. self bar. Rated 16 km from Queen Cable Car Station and 22 km from Vincom Plaza Ha Long, this resort features a shared lounge and terrace. The property offers a 24-hour front desk, a service room and currency exchange for guests. At Lapinta Cruise Lan Ha Bay, each room is equipped with a wardrobe, air conditioning and a work desk. The property serves a buffet breakfast and a la carte breakfast every morning. Cycling and fishing are popular activities in the area. Guests can also rent a car at Lapinta Cruise Lan Ha Bay. The yacht is 23 km from Quang Ninh Museum and 12 km from Ha Long Marine Plaza. The nearest airport is Cat Bi International Airport, 70 km from Lapinta Cruise Lan Ha Bay. The property offers airport shuttle service for an account surcharge.<br />Address: Got Pier, Ha Long, Viet Nam<br />Phone: (+84) 96 875 4312<br />Hotline: (+84) 968 754 312<br />Email: info@halongbaylapintacruise.com</p>",
    Status = 1,
    CreatedAt = Convert.ToDateTime("2017-08-09T23:49:58+02:00")
},
new Hotel()
{
    Id = "HT_9",
    Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656760259/hotel/259579741_wnvio0.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656760259/hotel/259579763_ogkx4o.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656760259/hotel/261213852_ohfm75.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656760259/hotel/259579772_d0ifhr.jpg",
    Name = "Ramada Hotel & Suites by Wyndham Halong Bay View",
    LocationId = "LOCAL_10",
    Rating = 5,
    Address = "To Hien Thanh, Tran Hung Dao, Ha Long, Viet Nam",
    Price = 40,
    Description = "Located in Ha Long, less than 1 km from Vincom Plaza Ha Long, Ramada Hotel & Suites Halong Bay offers accommodation with a TV screen and a kitchen. Guests can access free WiFi here. Cable Car.",
    Detail = "<p>Ramada Hotel &amp; Suites by Wyndham Halong Bay View is the first international standard 5 * hotel in Hon Gai, Ha Long city. All guests staying here can fully enjoy the modern infrastructure system, 360-degree panoramic views, Ha Long Bay, Sun Wheel, Bai Chay Bridge, Sun World Park. Ramada Hotel &amp; Suites by Wyndham Halong Bay View is designed in a modern style, taking advantage of natural light, giving customers a feeling of luxury, class but extremely comfortable like their own home. The hotel has an infinity pool on the 31st floor which is an ideal check-in location and many other unique facilities: royal garden, Skybar, Wine - Cigar bar, Gym area, Karaoke, Spa party room, conference room. Staying at Ramada Hotel &amp; Suites by Wyndham HaLong Bay View helps you maximize your energy for a new day of excitement. At Ramada Ha Long Bay View, every room has an open view of the bay or the city. Modern design, spacious, smart interior, rooms are equipped with high quality fabrics, protectors and feathers, luxurious and comfortable for. The hotel has many facilities such as outdoor infinity atmosphere, meeting rooms, restaurants, drinks. Spa services, gym, superb garden and outdoor furniture are being completed and sure to give customers the best experience.<br />Address: To Hien Thanh, Tran Hung Dao, Ha Long, Viet Nam<br />Phone: (+84) 2033 853 666<br />Hotline: (+84) 0826 111 555<br />Email: info@ramadasuiteshalongbay.com</p>",
    Status = 1,
    CreatedAt = Convert.ToDateTime("2017-09-09T23:49:58+02:00")
},
new Hotel()
{
    Id = "HT_10",
    Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656760392/hotel/249139563_qxffvn.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656760392/hotel/365532674_kogxw0.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656760392/hotel/279954301_cwt7aj.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656760392/hotel/366125012_x1daoy.jpg",
    Name = "Seashells Phu Quoc Hotel & Spa",
    LocationId = "LOCAL_5",
    Rating = 5,
    Address = " Vo Thi Sau, Duong Dong, Phu Quoc, Viet Nam",
    Price = 42,
    Description = "The property is a 2-minute walk from the beach. Seashells Phu Quoc Hotel & Spa is located in Duong Dong town, Phu Quoc island and features modern rooms with free WiFi connection. This hotel features an outdoor pool and a restaurant.",
    Detail = "<p>Located in the heart of Phu Quoc Island, Seashells Phu Quoc Hotel is a great place to stay when you set foot on the most beautiful islands in Vietnam. With the direct sea, the location allows customers to have access to the light yellow sand and the picturesque blue water of the island. At the same time it is very convenient to go to shopping, entertainment and looking for a life of play within a few minutes walk. Apart from Phu Quoc International Airport, it is only a 20-minute drive from the hotel. With our 252 ocean view and city view rooms &amp; suites, I bring unprecedented experiences to customers. Explore 4 restaurants &amp; manage guests with their own culinary methods. Coral Restaurant offers all-day dining with Phu Quoc specialties and mouthwatering international dishes as Anchor Bistro follows up with a selection of grilled dishes and a special wine collection to end the day in the sunset. romantic. Find inner peace at Sea Serenity Spa, connecting body and soul. Inspired by oriental methods, our Spa, I bring you an idyllic retreat, temporarily away from the rhythm of life returning to an oasis with a relaxing aroma. Other amenities include the Lobby Lounge, Cocoon Beach Lounge, Shell Bakery, Boat Gym and Turtle Kid's Club. Besides, the hotel provides modern conference &amp; meeting facilities with a function space of 970 square meters. High speed web is available in rooms and hotels. Enjoy your break with a whole new Pearl Island experience at Seashells Phu Quoc Hotel!<br />Address: Vo Thi Sau, Duong Dong, Phu Quoc, Viet Nam<br />Phone: (+84) 297 3923 999<br />Hotline: (+84) 297 3960 777<br />Email: reservation@seashellshotel.vn</p>",
    Status = 1,
    CreatedAt = Convert.ToDateTime("2017-10-09T23:49:58+02:00")
},
new Hotel()
{
    Id = "HT_11",
    Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656760537/hotel/326154310_b5cnmz.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656760537/hotel/266343483_yjvd1r.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656760538/hotel/249154120_wspvvc.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656760537/hotel/327267043_uodznz.jpg",
    Name = "Carlton Hotel Bangkok Sukhumvit",
    LocationId = "LOCAL_2",
    Rating = 5,
    Address = "Carlton Hotel Bangkok Sukhumvit, 491 Sukhumvit Rd. Klongtoey Nua, Wattana, Wattana, 10110 Bangkok, Thai Lan",
    Price = 65,
    Description = "Located in Bangkok, less than 1 km from Shopping Mall, Carlton Hotel Bangkok Sukhumvit offers accommodation with a restaurant, free private parking, an outdoor swimming pool and a fitness centre. This 5-star hotel has a kids club and especially a concierge service.",
    Detail = "<p>Welcome to Bangkok, Southeast Asia&rsquo;s most exciting and exotic city. Here, you will be immersed in a world that is not only uniquely Thai but uniquely Bangkok; a fascinating fusion enriched by the glories of the past and enlivened by creative contemporary culture. Carlton Hotel Bangkok Sukhumvit is one of the most luxurious and refined new five-star hotels in Bangkok. Stylish and contemporary, the hotel offers 338 elegant rooms and suites, a choice of renowned dining venues including the signature Cantonese restaurant, Wah Lok, and a Cooling Tower rooftop bar with panoramic views of the cityscape. Guests can take time out to relax beside the 30 meter swimming pool, enjoy a rejuvenating treatment in a tranquil spa, or an invigorating work-out at the Fitness Studio, and a fun Kids Zone Carlton Hotel Bangkok Sukhumvit is prestigious venue for meetings, incentives, conferences, and events. Excellent facilities. A total of 1,200 sq.m. of meetings and events space are available. Flexible venues include a large pre-function and breakout area filled with natural light, and The Grand Ballroom, an impressive room which can house up to 600 people. With a dramatic wave-like chandelier, carpet and paneled walls, it is the ideal setting for weddings, corporate functions, social events and banquets.<br />Address: Carlton Hotel Bangkok Sukhumvit, 491 Sukhumvit Rd. Klongtoey Nua, Wattana, Wattana, 10110 Bangkok, Thai Lan<br />Phone: (+66) 20 907 888<br />Hotline: (+66) 662 090 7889<br />Email: enquiry@carltonhotel.co.th</p>",
    Status = 1,
    CreatedAt = Convert.ToDateTime("2017-11-09T23:49:58+02:00")
},
    new Hotel()
    {
        Id = "HT_12",
        Thumbnail = "https://res.cloudinary.com/linh14092001/image/upload/v1656761153/hotel/190564130_rnxqgt.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656761153/hotel/254322657_bjxkyl.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656761153/hotel/251915524_jztujj.jpg , https://res.cloudinary.com/linh14092001/image/upload/v1656761153/hotel/254323232_zbq15e.jpg",
        Name = "Newhall Mains",
        LocationId = "LOCAL_6",
        Rating = 5,
        Address = "Newhall Mains, Balblair, Resolis, IV7 8LQ, Vuong Quoc Anh",
        Price = 80,
        Description = "Enjoy the pinnacle of world-class service at Newhall Mains. Located on the Black Isle in the heart of the Scottish Highlands, Newhall Mains is a collection of cottages, set within a courtyard building dating from 18th century.",
        Detail = "<p>Newhall Mains is a careful re-invention of the traditional &ldquo;Mains&rdquo; building &mdash; a Scottish term historically used to refer to the main buildings of a farm or working estate. With spacious interior living spaces, including five individually themed cottages and four double bedroom suites, our accommodation is designed to meet the needs of the modern traveller. Elegant interiors, modern conveniences and private surroundings are just some of the details that make a stay with us unique. From Robert Welch cutlery to St&ouml;lzle glassware we have everything you need for the ultimate home-from-home comfort. Our beds are handmade to the highest standards, with white linen, soft pillows and 100 per cent natural sheep wool quilts to help you slip into a long, comfortable sleep. Breakfast, picnics &amp; dinner are all available at Newhall Mains. Nestled in the heart of the Cromarty Firth, our private grass strip measures 630m in length and is situated 8nm north-west of Inverness airport. Smooth, levelled terrain, clear approaches and accommodating airspace make for a perfect GA retreat.<br />Address: Newhall Mains, Balblair, Resolis, IV7 8LQ, Vuong Quoc Anh<br />Phone: (+44) 138 1632 032<br />Hotline: (+44) 238 484 384&nbsp;<br />Email: INFO@NEWHALLMAINS.COM</p>",
        Status = 1,
        CreatedAt = Convert.ToDateTime("2017-12-09T23:49:58+02:00")
    }

                );
            //Chuyến bay
            context.Flights.AddOrUpdate(x => x.Id,
        new Flight()
        {
            Id = "FL_1",
            Thumbnail = "https://statics.vinpearl.com/cac-duong-bay-den-phu-quoc-1_1634653176.jpg",
            IsRoundTicket = false,
            DepartureId = "LOCAL_1",
            DestinationId = "LOCAL_2",
            DepartureAt = Convert.ToDateTime("2023-02-01T23:49:58+02:00"),
            Duration = "2",
            Price = 20,
            ReturnAt = Convert.ToDateTime("2023-02-09T23:49:58+02:00"),
            Detail = "Brand : Vietnam Airlines - Flight : VN 600 - Boarding Time : 14:00",
            Status = 1,
            CreatedAt = DateTime.Now
        },
                new Flight()
                {
                    Id = "FL_2",
                    Thumbnail = "https://www.airdatanews.com/wp-content/uploads/2022/04/747youtube.jpg",
                    IsRoundTicket = true,
                    DepartureId = "LOCAL_1",
                    DestinationId = "LOCAL_4",
                    DepartureAt = Convert.ToDateTime("2022-12-10T23:49:58+02:00"),
                    Duration = "3",
                    Price = 23,
                    ReturnAt = Convert.ToDateTime("2022-12-20T23:49:58+02:00"),
                    Detail = "Good news for all you travelers flying from Hanoi - right now, we're offering huge deals on roundtrip flights to Da Nang! So whether you're a frequent business traveler, or if you're just looking to get out of town for a while, you can fly for less. And don't forget, CheapOair also has great deals on hotels and cars waiting for you when you land. So don't delay - grab a cheap ticket to Da Nang today!",
                    Status = 1,
                    CreatedAt = DateTime.Now
                },

        new Flight()
        {
            Id = "FL_3",
            Thumbnail = "https://kenyanwallstreet.com/wp-content/uploads/2022/01/emirates-planes-to-replace-windows-with-virtual-views-126208_1.jpeg",
            IsRoundTicket = true,
            DepartureId = "LOCAL_1",
            DestinationId = "LOCAL_3",
            DepartureAt = Convert.ToDateTime("2022-12-01T23:49:58+02:00"),
            Duration = "3",
            Price = 30,
            ReturnAt = Convert.ToDateTime("2022-12-08T23:49:58+02:00"),
            Detail = "Good news for all you travelers flying from Hanoi - right now, we're offering huge deals on roundtrip flights to Bangkok! So whether you're a frequent business traveler, or if you're just looking to get out of town for a while, you can fly for less. And don't forget, CheapOair also has great deals on hotels and cars waiting for you when you land. So don't delay - grab a cheap ticket to Bangkok today!",
            Status = 1,
            CreatedAt = DateTime.Now
        },
                        new Flight()
                        {
                            Id = "FL_4",
                            Thumbnail = "https://media.cntraveler.com/photos/581250f2997d59497dccf8bc/16:9/w_2560%2Cc_limit/GettyImages-185298837.jpg",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_7",
                            DestinationId = "LOCAL_8",
                            DepartureAt = Convert.ToDateTime("2022-12-08T23:49:58+02:00"),
                            Duration = "3",
                            Price = 25,
                            ReturnAt = Convert.ToDateTime("2022-12-15T23:49:58+02:00"),
                            Detail = "Right now is a great time to book your flight to Turkey! We're offering some truly incredible roundtrip deals. So whether you're a frequent business traveler, or if you're just looking to get out of town for a while, you can fly for less. And don't forget",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_5",
                            Thumbnail = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVx1sJ-TDZwJkT291_L5y-wEa6S_DJE-O6bvS928SWUUYee_Pg8xtiCMOupA04s5w_8cQ&usqp=CAU",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_11",
                            DestinationId = "LOCAL_12",
                            DepartureAt = Convert.ToDateTime("2022-08-30T23:49:58+02:00"),
                            Duration = "5",
                            Price = 20,
                            ReturnAt = Convert.ToDateTime("2022-09-10T23:49:58+02:00"),
                            Detail = "By allowing the codeshare carrier and flight number in the flight service response, users can respond to questions and problems both pre- and post-departure without having to call Travelport to obtain the data",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_6",
                            Thumbnail = "https://www.india.com/wp-content/uploads/2022/03/International-Flights-Latest-Update.jpg",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_1",
                            DestinationId = "LOCAL_4",
                            DepartureAt = Convert.ToDateTime("2022-12-09T23:49:58+02:00"),
                            Duration = "2",
                            Price = 20,
                            ReturnAt = Convert.ToDateTime("2022-12-17T23:49:58+02:00"),
                            Detail = "Good news for all you travelers flying from Da Nang - right now, we're offering huge deals on roundtrip flights to Hanoi! So whether you're a frequent business traveler, or if you're just looking to get out of town for a while, you can fly for less. And don't forget, CheapOair also has great deals on hotels and cars waiting for you when you land. So don't delay - grab a cheap ticket to Hanoi today!",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_7",
                            Thumbnail = "https://baokhanhhoa.vn/dataimages/202003/original/images5396717_hang_hang_khong_vietjet_air.jpg",
                            IsRoundTicket = false,
                            DepartureId = "LOCAL_1",
                            DestinationId = "LOCAL_6",
                            DepartureAt = Convert.ToDateTime("2022-11-25T23:49:58+02:00"),
                            Duration = "2",
                            Price = 15,
                            ReturnAt = Convert.ToDateTime("2022-11-30T23:49:58+02:00"),
                            Detail = "Brand : Vietnam Airlines - Flight : VN 600 - Boarding Time : 14:00",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_8",
                            Thumbnail = "https://i.pinimg.com/736x/2f/2d/46/2f2d468cd29591b0df319f4d6ca7989b.jpg",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_4",
                            DestinationId = "LOCAL_7",
                            DepartureAt = Convert.ToDateTime("2022-08-29T23:49:58+02:00"),
                            Duration = "1",
                            Price = 10,
                            ReturnAt = Convert.ToDateTime("2022-09-05T23:49:58+02:00"),
                            Detail = "The enhancement with Release 21.2.2 improves the accuracy of the Transportation Security Administration (TSA) informational message by replacing the specific United States based text",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_9",
                            Thumbnail = "https://www.westjet.com/book/media_18faa7ea90de73b53dbc9bc9eb04e5b5e9a604049.png?width=750&format=png&optimize=medium",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_1",
                            DestinationId = "LOCAL_3",
                            DepartureAt = Convert.ToDateTime("2022-12-02T23:49:58+02:00"),
                            Duration = "2.5",
                            Price = 20,
                            ReturnAt = Convert.ToDateTime("2022-12-09T23:49:58+02:00"),
                            Detail = "The availability and types of Flight Details returned vary by carrier and segment. The availability of real-time data versus scheduled data may also vary by carrier and segment",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_10",
                            Thumbnail = "https://ichef.bbci.co.uk/news/976/cpsprodpb/8927/production/_123311153_paleedsbradford.jpg",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_10",
                            DestinationId = "LOCAL_11",
                            DepartureAt = Convert.ToDateTime("2022-07-10T23:49:58+02:00"),
                            Duration = "1",
                            Price = 15,
                            ReturnAt = Convert.ToDateTime("2022-07-09T23:49:58+02:00"),
                            Detail = "Prior to Air v48.0, the CodeshareInfo attribute contained within the FlightDetails element had a Max Occurrence of 0",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_11",
                            Thumbnail = "https://akm-img-a-in.tosshub.com/indiatoday/images/story/202201/air_india_reuters.joeg_1200x768.jpeg?p4dqL.Y5YYVUP83CY5DW2WMFPpmMqk13&size=770:433",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_1",
                            DestinationId = "LOCAL_12",
                            DepartureAt = Convert.ToDateTime("2023-03-05T23:49:58+02:00"),
                            Duration = "4",
                            Price = 20,
                            ReturnAt = Convert.ToDateTime("2023-03-09T23:49:58+02:00"),
                            Detail = "By allowing the codeshare carrier and flight number in the flight service response, users can respond to questions and problems both pre- and post-departure without having to call Travelport to obtain the data",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_12",
                            Thumbnail = "https://assets.telegraphindia.com/telegraph/2020/Jul/1595972233_1594320268_shutterstock_699697081.jpg",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_3",
                            DestinationId = "LOCAL_4",
                            DepartureAt = Convert.ToDateTime("2022-12-25T23:49:58+02:00"),
                            Duration = "2",
                            Price = 20,
                            ReturnAt = Convert.ToDateTime("2022-12-31T23:49:58+02:00"),
                            Detail = "Prior to Universal API release 21.2.2, the InFlightService list returns a value of TSA SECURED FLIGHT if a flight was a TSA-secured flight",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_13",
                            Thumbnail = "https://www.airport-data.com/images/aircraft/001/484/001484512.jpg",
                            IsRoundTicket = false,
                            DepartureId = "LOCAL_6",
                            DestinationId = "LOCAL_7",
                            DepartureAt = Convert.ToDateTime("2022-11-20T23:49:58+02:00"),
                            Duration = "2",
                            ReturnAt = Convert.ToDateTime("2022-11-29T23:49:58+02:00"),
                            Price = 20,
                            Detail = "Brand : Vietnam Airlines - Flight : VN 600 - Boarding Time : 14:00",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_14",
                            Thumbnail = "https://webcdn.infiniteflight.com/blog/content/images/2021/05/infinite-flight-21-1-release.jpg",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_12",
                            DestinationId = "LOCAL_11",
                            DepartureAt = Convert.ToDateTime("2023-01-09T23:49:58+02:00"),
                            Duration = "3",
                            Price = 23,
                            ReturnAt = Convert.ToDateTime("2023-01-12T23:49:58+02:00"),
                            Detail = "The enhancement with Release 21.2.2 improves the accuracy of the Transportation Security Administration (TSA) informational message by replacing the specific United States based text",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_15",
                            Thumbnail = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3c/Cathay_Pacific_Boeing_777-200%3B_B-HNL%40HKG.jpg/1200px-Cathay_Pacific_Boeing_777-200%3B_B-HNL%40HKG.jpg",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_10",
                            DestinationId = "LOCAL_9",
                            DepartureAt = Convert.ToDateTime("2022-12-23T23:49:58+02:00"),
                            Duration = "3",
                            Price = 25,
                            ReturnAt = Convert.ToDateTime("2022-12-30T23:49:58+02:00"),
                            Detail = "The availability and types of Flight Details returned vary by carrier and segment. The availability of real-time data versus scheduled data may also vary by carrier and segment",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_16",
                            Thumbnail = "https://media.cntraveler.com/photos/581250f2997d59497dccf8bc/16:9/w_2560%2Cc_limit/GettyImages-185298837.jpg",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_7",
                            DestinationId = "LOCAL_8",
                            DepartureAt = Convert.ToDateTime("2022-07-09T23:49:58+02:00"),
                            Duration = "3",
                            Price = 25,
                            ReturnAt = Convert.ToDateTime("2022-07-18T23:49:58+02:00"),
                            Detail = "Prior to Air v48.0, the CodeshareInfo attribute contained within the FlightDetails element had a Max Occurrence of 0",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_17",
                            Thumbnail = "https://www.super-hobby.com/zdjecia/7/0/5/15098_rd.jpg",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_5",
                            DestinationId = "LOCAL_6",
                            DepartureAt = Convert.ToDateTime("2022-08-09T23:49:58+02:00"),
                            Duration = "2",
                            Price = 10,
                            ReturnAt = Convert.ToDateTime("2022-08-15T23:49:58+02:00"),
                            Detail = "By allowing the codeshare carrier and flight number in the flight service response, users can respond to questions and problems both pre- and post-departure without having to call Travelport to obtain the data",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        },
                        new Flight()
                        {
                            Id = "FL_18",
                            Thumbnail = "https://i.insider.com/61e8031d04ce6e0018d7afec?width=700",
                            IsRoundTicket = true,
                            DepartureId = "LOCAL_2",
                            DestinationId = "LOCAL_4",
                            DepartureAt = Convert.ToDateTime("2022-12-09T23:49:58+02:00"),
                            Duration = "2",
                            Price = 15,
                            ReturnAt = Convert.ToDateTime("2022-12-10T23:49:58+02:00"),
                            Detail = "Prior to Universal API release 21.2.2, the InFlightService list returns a value of TSA SECURED FLIGHT if a flight was a TSA-secured flight",
                            Status = 1,
                            CreatedAt = DateTime.Now
                        }
                );
            var userId = db.Users.Select(u => u.Id).ToList();

            var tourDetail = db.TourDetails.ToList();

            var carList = db.Cars.ToList();




            for (int i = 1; i < 50; i++)
            {
                var orderId = "ORD_" + i;
                if (db.Orders.Find(orderId) != null)
                {
                    continue;
                }
                var tourDetailChosen = tourDetail.OrderBy(s => Guid.NewGuid()).First();
                var unitPrice = tourDetailChosen.Price * (1 - tourDetailChosen.Discount / 100);
                int randomQuantity = gen.Next(1, 10);
                int random = gen.Next(1, 11);
                var totalPrice = unitPrice * randomQuantity;
                context.Orders.AddOrUpdate(x => x.Id,
                    new Order()
                    {
                        Id = orderId,
                        UserId = userId.OrderBy(s => Guid.NewGuid()).First(),
                        TotalPrice = totalPrice,
                        Type = 1,
                        Status = 1,
                        CreatedAt = GetRandomDate(DateTime.Now.AddYears(-4), DateTime.Now)
                    }
                    );
                context.OrderTours.AddOrUpdate(x => new { x.OrderId, x.TourDetailId },
                    new OrderTour()
                    {
                        OrderId = orderId,
                        TourDetailId = tourDetailChosen.Id,
                        UnitPrice = unitPrice,
                        Quantity = randomQuantity
                    }
                    );
            }

            for (int i = 51; i < 90; i++)
            {
                var orderId = "ORD_" + i;
                if (db.Orders.Find(orderId) != null)
                {
                    continue;
                }
                var carChosen = carList.OrderBy(s => Guid.NewGuid()).First();
                var carStartDay = RandomDay();
                int randomDuration = gen.Next(1, 10);
                var unitPrice = carChosen.PricePerDay * randomDuration;
                var createdAt = GetRandomDate(carStartDay.AddDays(-randomDuration), carStartDay);
                context.Orders.AddOrUpdate(x => x.Id,
                    new Order()
                    {
                        Id = orderId,
                        UserId = userId.OrderBy(s => Guid.NewGuid()).First(),
                        TotalPrice = unitPrice,
                        Type = 2,
                        Status = 1,
                        CreatedAt = createdAt
                    }
                    );
                context.CarSchedules.AddOrUpdate(x => x.Id,
                new CarSchedule()
                {
                    Id = "CARSCH_" + i,
                    CarId = carChosen.Id,
                    StartDay = carStartDay.Date,
                    EndDay = carStartDay.AddDays(randomDuration).Date,
                    Status = 3,
                    CreatedAt = createdAt
                }
                );
                context.OrderCars.AddOrUpdate(x => new { x.OrderId, x.CarScheduleId },
                  new OrderCar()
                  {
                      OrderId = orderId,
                      CarScheduleId = "CARSCH_" + i,
                      UnitPrice = unitPrice,
                  }
                  );

            }


            //totalPrice của refund là kết quả sau khi nhân với percent
            //context.Refunds.AddOrUpdate(x => x.Id,
            //    new Refund()
            //    {
            //        Id = "RF_1",
            //        Percent = 90,
            //        TotalPrice = 1080,
            //        Status = 1,
            //        CreatedAt = Convert.ToDateTime("2017-08-09T23:49:58+02:00"),
            //        UpdatedAt = DateTime.Now,
            //        DeletedAt = DateTime.Now,
            //    }
            //    );

            db.SaveChanges();
        }

    }
}
