using OpenQA.Selenium.Support.UI;

namespace Pages;

public abstract class BasePage : LoadableComponent<BasePage>
{
    public bool IsOpened => IsLoaded;
}
