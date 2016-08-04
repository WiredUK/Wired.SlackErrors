# Wired.SlackErrors #

Push unhandled errors in an ASP.Net project directly into a [Slack](https://slack.com) channel.

## Documentation ##

Setting up is nice and easy. First you need to get a URL from your Slack channel.

1.  Open up the custom integration builder from your Slack app, the URL will be something like this:

        https://<your-app-name>.slack.com/apps/build/custom-integration

2.  Create a new _Incoming WebHook_.
3.  Choose the channel you want to post to and click _Add_.
4.  Note the _WebHook URL_, this is what you need in all the web applications that you want to post into this channel.
5.  Install the _Wired.SlackErrors_ library into your app by manually referencing the DLL or adding the Nuget package (adding to Nuget is a TODO for me!)
6.  In your `web.config` file, you need to add the following line into the `configSections` element. This registers the configuration element in the next step

    <section name="slackErrors" type="Wired.SlackErrors.Module.Configuration.SlackErrorsConfiguration, Wired.SlackErrors.Module" />

7.  Add in the following configuration element:

        <slackErrors appName="<website name>">
            <channels>
                <add name="<channel name>"
                     postUrl="<webhoook-url>" />
            </channels>
        </slackErrors>

8. Make sure to replace the `appName` (this is posted into teh Slack channel so you can easily identify the error source), the channel name (this is only useful for you to identify where the URL is posting to) and the `postUrl` (as given above in the Slack configuration)

That's all that is needed. Now any unhandled errors (those pesky things that cause your ASP.Net application to show the yellow screen of death) will get posted to Slack.

## Filtering ##

It is possible to filter the errors that get posted, this is especially useful if you are only interested in specific error type or you're looking for specific text in the stack trace. You can filter on exception type or stack trace, for example this will ensure that only `NullReferenceException` exceptions are sent to Slack:

    <add name="Website Errors Channel" 
         postUrl="https://hooks.slack.com/services/..." 
         typeFilter="System.NullReferenceException" />

If you want to filter on stack trace, use `traceFilter` instead:

    <add name="Website Errors Channel" 
         postUrl="https://hooks.slack.com/services/..." 
         traceFilter="......" />

Both `traceFilter` and `traceFilter` use [regular expressions](https://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex(v=vs.110).aspx) to match.
