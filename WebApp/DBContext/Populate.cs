

using WebApp.Models;
using WebApp.Models.Enums;

namespace WebApp
{
    public class Populate(WebAppContext webApp)
    {
        private WebAppContext _context = webApp;

        public void Seed()
        {
            _context.Database.EnsureCreated();
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecords.Any()) return;
            Department d1 = new(1, "Computers");
            Department d2 = new(2, "Electronics");
            Department d3 = new(3, "Fashion");
            Department d4 = new(4, "Books");

            Seller s1 = new(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
            Seller s2 = new(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0, d2);
            Seller s3 = new(3, "Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0, d1);
            Seller s4 = new(4, "Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0, d4);
            Seller s5 = new(5, "Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0, d3);
            Seller s6 = new(6, "Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0, d2);

            SalesRecords r1 = new(1, new DateTime(2018, 09, 25), 11000.0, SalesStatus.Billed, s1);
            SalesRecords r2 = new(2, new DateTime(2018, 09, 4), 7000.0, SalesStatus.Billed, s5);
            SalesRecords r3 = new(3, new DateTime(2018, 09, 13), 4000.0, SalesStatus.Cancelled, s4);
            SalesRecords r4 = new(4, new DateTime(2018, 09, 1), 8000.0, SalesStatus.Billed, s1);
            SalesRecords r5 = new(5, new DateTime(2018, 09, 21), 3000.0, SalesStatus.Billed, s3);
            SalesRecords r6 = new(6, new DateTime(2018, 09, 15), 2000.0, SalesStatus.Billed, s1);
            SalesRecords r7 = new(7, new DateTime(2018, 09, 28), 13000.0, SalesStatus.Billed, s2);
            SalesRecords r8 = new(8, new DateTime(2018, 09, 11), 4000.0, SalesStatus.Billed, s4);
            SalesRecords r9 = new(9, new DateTime(2018, 09, 14), 11000.0, SalesStatus.Pending, s6);
            SalesRecords r10 = new(10, new DateTime(2018, 09, 7), 9000.0, SalesStatus.Billed, s6);
            SalesRecords r11 = new(11, new DateTime(2018, 09, 13), 6000.0, SalesStatus.Billed, s2);
            SalesRecords r12 = new(12, new DateTime(2018, 09, 25), 7000.0, SalesStatus.Pending, s3);
            SalesRecords r13 = new(13, new DateTime(2018, 09, 29), 10000.0, SalesStatus.Billed, s4);
            SalesRecords r14 = new(14, new DateTime(2018, 09, 4), 3000.0, SalesStatus.Billed, s5);
            SalesRecords r15 = new(15, new DateTime(2018, 09, 12), 4000.0, SalesStatus.Billed, s1);
            SalesRecords r16 = new(16, new DateTime(2018, 10, 5), 2000.0, SalesStatus.Billed, s4);
            SalesRecords r17 = new(17, new DateTime(2018, 10, 1), 12000.0, SalesStatus.Billed, s1);
            SalesRecords r18 = new(18, new DateTime(2018, 10, 24), 6000.0, SalesStatus.Billed, s3);
            SalesRecords r19 = new(19, new DateTime(2018, 10, 22), 8000.0, SalesStatus.Billed, s5);
            SalesRecords r20 = new(20, new DateTime(2018, 10, 15), 8000.0, SalesStatus.Billed, s6);
            SalesRecords r21 = new(21, new DateTime(2018, 10, 17), 9000.0, SalesStatus.Billed, s2);
            SalesRecords r22 = new(22, new DateTime(2018, 10, 24), 4000.0, SalesStatus.Billed, s4);
            SalesRecords r23 = new(23, new DateTime(2018, 10, 19), 11000.0, SalesStatus.Cancelled, s2);
            SalesRecords r24 = new(24, new DateTime(2018, 10, 12), 8000.0, SalesStatus.Billed, s5);
            SalesRecords r25 = new(25, new DateTime(2018, 10, 31), 7000.0, SalesStatus.Billed, s3);
            SalesRecords r26 = new(26, new DateTime(2018, 10, 6), 5000.0, SalesStatus.Billed, s4);
            SalesRecords r27 = new(27, new DateTime(2018, 10, 13), 9000.0, SalesStatus.Pending, s1);
            SalesRecords r28 = new(28, new DateTime(2018, 10, 7), 4000.0, SalesStatus.Billed, s3);
            SalesRecords r29 = new(29, new DateTime(2018, 10, 23), 12000.0, SalesStatus.Billed, s5);
            SalesRecords r30 = new(30, new DateTime(2018, 10, 12), 5000.0, SalesStatus.Billed, s2);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecords.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();
        }
    }
}