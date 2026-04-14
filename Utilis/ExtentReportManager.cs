using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

public class ExtentReportManager
{
    private static ExtentReports? _extent;
    public static ExtentTest? Test;

    public static ExtentReports GetInstance()
    {
        if (_extent == null)
        {
            var htmlReporter = new ExtentSparkReporter("Reports/index.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }
        return _extent;
    }
}