using NUnit.Framework;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium;

using OpenQA.Selenium.Firefox;

using System;

using System.Collections.ObjectModel;

using System.IO;
using System.Text;
using OpenQA.Selenium.BiDi.Communication;
using System.Data;

[TestFixture]
public class YourTestClass
{
    private ChromeDriver driver;

    [OneTimeSetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        // Initialize your driver here
    }

    [Test]
    public void registerclient()
    {
        driver.Navigate().GoToUrl("https://localhost/interface/smart/register-app.php");
        driver.FindElement(By.Id("details-button")).Click();
        driver.FindElement(By.Id("proceed-link")).Click();
        driver.FindElement(By.Id("appTypePublic")).Click();
        driver.FindElement(By.Id("appName")).SendKeys("appName7");
        driver.FindElement(By.Id("contactEmail")).SendKeys("ajab.nagesh@gmail.com");
        driver.FindElement(By.Id("redirectUri")).SendKeys("https://localhost/swagger/oauth2-redirect.html");
        driver.FindElement(By.Id("launchUri")).SendKeys("https://localhost/swagger/index.html");

        //select scopes
        driver.FindElement(By.Name("scope[offline_access]")).Click();
        driver.FindElement(By.Name("scope[user/AllergyIntolerance.read]")).Click();
        driver.FindElement(By.Name("scope[user/Appointment.read]")).Click();
        driver.FindElement(By.Name("scope[user/Binary.read]")).Click();
        driver.FindElement(By.Name("scope[user/CarePlan.read]")).Click();
        driver.FindElement(By.Name("scope[user/CareTeam.read]")).Click();
        driver.FindElement(By.Name("scope[user/Condition.read]")).Click();
        driver.FindElement(By.Name("scope[user/Coverage.read]")).Click();
        driver.FindElement(By.Name("scope[user/Device.read]")).Click();
        driver.FindElement(By.Name("scope[user/DiagnosticReport.read]")).Click();
        driver.FindElement(By.Name("scope[user/DocumentReference.$docref]")).Click();
        driver.FindElement(By.Name("scope[user/DocumentReference.read]")).Click();
        driver.FindElement(By.Name("scope[user/Encounter.read]")).Click();
        driver.FindElement(By.Name("scope[user/Goal.read]")).Click();
        driver.FindElement(By.Name("scope[user/Immunization.read]")).Click();
        driver.FindElement(By.Name("scope[user/Location.read]")).Click();
        driver.FindElement(By.Name("scope[user/Medication.read]")).Click();
        driver.FindElement(By.Name("scope[user/MedicationRequest.read]")).Click();
        driver.FindElement(By.Name("scope[user/Observation.read]")).Click();
        driver.FindElement(By.Name("scope[user/Organization.read]")).Click();        
        driver.FindElement(By.Name("scope[user/Organization.write]")).Click();
        driver.FindElement(By.Name("scope[user/Patient.read]")).Click();
        driver.FindElement(By.Name("scope[user/Patient.write]")).Click();
        driver.FindElement(By.Name("scope[user/Person.read]")).Click();
        driver.FindElement(By.Name("scope[user/Practitioner.read]")).Click();
        driver.FindElement(By.Name("scope[user/Practitioner.write]")).Click();
        driver.FindElement(By.Name("scope[user/PractitionerRole.read]")).Click();
        driver.FindElement(By.Name("scope[user/Procedure.read]")).Click();
        driver.FindElement(By.Name("scope[user/Provenance.read]")).Click();

        driver.FindElement(By.Id("submit")).Click();

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        System.Threading.Thread.Sleep(3000);

        var clientid = driver.FindElement(By.Id("clientID")).GetAttribute("value");
        var audURL=driver.FindElement(By.Id("audURL")).GetAttribute("value");

        StringBuilder sb=new StringBuilder();
        sb.AppendLine(clientid);
        sb.AppendLine(audURL);
        File.WriteAllText("newclient.txt", sb.ToString());

        Console.WriteLine("clientid is "+ clientid);
        Console.WriteLine("audience url is " +audURL);

        driver.Navigate().GoToUrl("https://localhost/swagger");
        driver.FindElement(By.XPath( "//span[text()='Authorize']")).Click();
        //driver.FindElement(By.ClassName("btn authorize unlocked")).Click();
        driver.FindElement(By.Id("client_id")).SendKeys(clientid);

        //select scopes
        driver.FindElement(By.XPath("//a[text()='select all']")).Click();
        driver.FindElement(By.XPath("//p[text()='offline_access']")).Click();

        driver.FindElement(By.XPath("//p[text()='system/AllergyIntolerance.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/AllergyIntolerance.read']")).Click();
        
        driver.FindElement(By.XPath("//p[text()='user/appointment.read']")).Click();
        
        driver.FindElement(By.XPath("//p[text()='user/Binary.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Binary.read']")).Click();
        
        driver.FindElement(By.XPath("//p[text()='user/CarePlan.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/CarePlan.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/CareTeam.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/CareTeam.read']")).Click();
        
        driver.FindElement(By.XPath("//p[text()='user/Condition.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Condition.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Coverage.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Coverage.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Device.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Device.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/DiagnosticReport.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/DiagnosticReport.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/DocumentReference.$docref']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/DocumentReference.$docref']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/DocumentReference.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/DocumentReference.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Encounter.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/encounter.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Encounter.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Goal.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Goal.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/immunization.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/Immunization.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Immunization.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Location.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Location.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Medication.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/medication.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Medication.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/MedicationRequest.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/MedicationRequest.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Observation.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Observation.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Organization.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Organization.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Organization.write']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Patient.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/patient.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Patient.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Patient.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/patient.write']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Person.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Person.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Practitioner.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/practitioner.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Practitioner.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Practitioner.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/practitioner.write']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/PractitionerRole.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/PractitionerRole.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Procedure.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Procedure.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/Provenance.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='system/Provenance.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='system/Group.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/allergy.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/allergy.write']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/appointment.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/dental_issue.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/dental_issue.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/document.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/document.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/drug.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/encounter.write']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/facility.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/facility.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/insurance.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/insurance.write']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/insurance_company.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/insurance_company.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/insurance_type.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/list.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/medical_problem.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/medical_problem.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/medication.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/message.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/prescription.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/procedure.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/soap_note.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/soap_note.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/surgery.read']")).Click();

        driver.FindElement(By.XPath("//p[text()='user/surgery.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/transaction.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/transaction.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/vital.read']")).Click();
        driver.FindElement(By.XPath("//p[text()='user/vital.write']")).Click();
        driver.FindElement(By.XPath("//p[text()='api:port']")).Click();

        driver.FindElement(By.XPath("//button[text()='Authorize']")).Click();
    }



    [OneTimeTearDown]
    public void TearDown()
    {
        if (driver != null)
        {
            driver.Dispose();
            driver = null;
        }
    }
}
