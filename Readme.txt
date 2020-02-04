
Chromium Driver:
Selenium webdrivers naming convention have changed. The Chrome driver to use shall match the Browser version.
I ran the test using the latest version of Chrome (79). As such, I have installed chormium driver version 79. If you need to test with a different version of Chrome, please download the chromium driver here.
Or you can just upgrade to the latest Chrome 79.

Selenium Webdriver:
I found the stable version is from year 2017, version 3.5.1 . Please download this version. Also download Selenium Support 3.5.1

Logging:
This uses the package SeleniumLog from NuGet. It is an Open Source logging I developed some years ago for Selenium Webdriver. The log.txt is in the Output folder, Debug or Release. 

Unit Test Framework:
I did not have time to create a NUnit test so in this test the Test Runner is the Main() console program. Ideally though Selenium tests should be created in one of the well-known
Unit Test frameworks, for ease of integration with third party tools such as SpecFlow, TFS, Jenkins, etc.
