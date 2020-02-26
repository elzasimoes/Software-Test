import io.appium.java_client.MobileElement;
import io.appium.java_client.android.AndroidDriver;
import junit.framework.TestCase;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import java.net.MalformedURLException;
import java.net.URL;
import org.openqa.selenium.remote.DesiredCapabilities;

public class SampleTest {

  private AndroidDriver driver;

  @Before
  public void setUp() throws MalformedURLException {
    DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
    desiredCapabilities.setCapability("platformName", "Android");
    desiredCapabilities.setCapability("deviceName", "192.168.62.103:5555");
    desiredCapabilities.setCapability("automationNAme", "uiautomator2");
    desiredCapabilities.setCapability("appActivity", "com.android.calculator2.Calculator");
    desiredCapabilities.setCapability("appPackage", "com.android.calculator2");

    URL remoteUrl = new URL("http://localhost:4723/wd/hub");

    driver = new AndroidDriver(remoteUrl, desiredCapabilities);
  }

  @Test
  public void sampleTest() {
    MobileElement el4 = (MobileElement) driver.findElementById("com.android.calculator2:id/digit_2");
    el4.click();
    MobileElement el5 = (MobileElement) driver.findElementByAccessibilityId("plus");
    el5.click();
    MobileElement el6 = (MobileElement) driver.findElementById("com.android.calculator2:id/digit_2");
    el6.click();
  }

  @After
  public void tearDown() {
    driver.quit();
  }
}
