//// See https://aka.ms/new-console-template for more information

//using MextFullStack.Domain;
//using MextFullStack.Domain.Entities;
//using MextFullStack.Domain.Enums;
//using System.Text;


//var filePath = "C:\\Users\\Melike Aydın\\Desktop\\UNDPBootcamp\\BootcampBenimProjelerim\\MextFullStack\\AccessControlLogs.txt";

//var accessControlLogsText = File.ReadAllText(filePath);

//var accessControlLogLines = accessControlLogsText.Split("\n", StringSplitOptions.RemoveEmptyEntries);

//List<AccessControlLog> accessControlLogs = new();

////var accessControlLogs = new List<AccessControlLog>();

//foreach (var logLine in accessControlLogLines)
//{
//    var accessControlLogData = logLine.Split("---", StringSplitOptions.RemoveEmptyEntries);

//    var accessControlLog = new AccessControlLog
//    {
//        Id = Guid.NewGuid(),
//        UserId = Convert.ToInt32(accessControlLogData[0]),
//        DeviceSerialNumber = accessControlLogData[1],
//        AccessType = Enum.Parse<AccessType>(accessControlLogData[2]),
//        Date = Convert.ToDateTime(accessControlLogData[3]),
//        CreatedOn = DateTime.Now
//    };

//    accessControlLogs.Add(accessControlLog);

//    Console.WriteLine($"Reading -> Access Control Log: {logLine}");
//}


////accessControlLogs = accessControlLogs
////    .Where(log => log.AccessType == AccessType.CARD || log.AccessType==AccessType.FP)
////    .ToList();

//accessControlLogs = accessControlLogs
//    .OrderBy(log => log.UserId)
//    .ToList();

//var userId = Convert.ToInt32(Console.ReadLine);

//var accessLog = accessControlLogs.LastOrDefault();

//if (accessLog == null)
//    Console.WriteLine("Girilen Id bilgisine ait kayıt bulunamadı.");
//else
//{
//    Console.WriteLine($"Single");
//}


//var random=new Random();

//StringBuilder stringBuilder = new StringBuilder();

//foreach (var accessControlLog in accessControlLogs)
//{
//    var randomNumber = random.Next(0, 10000);

//    accessControlLog.IsApproved = randomNumber % 2 != 0;

//    accessControlLog.ApprovedDate = DateTime.Now;

//    var content = $"Writing -> Access Control Log: {accessControlLog.UserId}---{accessControlLog.DeviceSerialNumber}---{accessControlLog.AccessType}---{accessControlLog.Date}---{accessControlLog.IsApproved}---{accessControlLog.ApprovedDate}";

//    Console.WriteLine(content);

//    stringBuilder.AppendLine(content);
//}

//var savePath = "C:\\Users\\Melike Aydın\\Desktop\\UNDPBootcamp\\BootcampBenimProjelerim\\MextFullStack\\CheckedAccessControlLogs.txt";

//File.AppendAllText(savePath, stringBuilder.ToString());

//Console.ReadLine();