# Lightstreamer StockList Demo Client for Microsoft Silverlight#

This project contains a simple Silverlight version of the [Lightstreamer Stock-List Demos](https://github.com/Weswit/Lightstreamer-example-Stocklist-client-javascript) fed through a Lightstreamer server.

## Silverlight Stock-List Demo ##

<table>
  <tr>
    <td style="text-align: left">
      &nbsp;<a href="http://demos.lightstreamer.com/Silverlight_StockListDemo" target="_blank"><img src="http://www.lightstreamer.com/img/demo/screen_silverlight.png"></a>&nbsp;
      
    </td>
    <td>
      &nbsp;An online demonstration is hosted on our servers at:<br>
      &nbsp;<a href="http://demos.lightstreamer.com/Silverlight_StockListDemo" target="_blank">http://demos.lightstreamer.com/Silverlight_StockListDemo/</a>
    </td>
  </tr>
</table>


This app uses the <b>Silverlight Client API for Lightstreamer</b> to handle the communications with Lightstreamer Server and uses a <b>Silverlight Grid</b> to display the real-time data pushed by Lightstreamer Server.<br>
After launching the demo, the Silverlight application will automatically connect to Lightstreamer Server and will subscribe to 30 stock quotes.<br>

A Silverlight Grid is used to display the real-time data. You can sort on any columns and drag the columns around (in this demo the resorting is not done automatically on each update).

# Build #

If you want to skip the build process of this demo please note that in the [deploy release](https://github.com/Weswit/Lightstreamer-example-Stocklist-client-silverlight/releases) of this project you can find the "deploy.zip" file that contains a deployment image of the demo, which includes the ".xap" file needed to contain all the resources that make up the demo (i.e. the demo DLL, the Lightstreamer client library DLL and, possibly, other SDK resources) and a container html page.
This deployment image is ready to be deployed under Lightstreamer's internal Web Server, by copying all the contents into some subfolder of the "pages" directory.<br>

Otherwise, in order to proceed with the build process of this demo, this project includes the following sub-folders:
* /Source<br>
  Contains the sources to build the Silverlight application from Visual Studio.

* /Properties<br>
  Contains the property files associated to the application sources.
  
* /Images<br>
  Contains the image files used by the Silverlight application.

* /lib<br>
  Should contain Lightstreamer Silverlight Client library, to be used for the build process.<br>
  Please, download the [latest Lightstreamer distribution](http://www.lightstreamer.com/download) and copy the SilverlightClient.dll and SilverlightClient.pdb files from the Lightstreamer Silverlight Client SDK (that is located under the /DOCS-SDKs/sdk_client_silverlight/lib folder) into this folder of the project.
  
<br>
The Silverlight Client Library is compatible with Silverlight environment version 3 or newer.

# Deploy #

If you have skipped the build process you should get the deploy folder of this demo from the [latest release](https://github.com/Weswit/Lightstreamer-example-Stocklist-client-silverlight/releases) of this project.
Otherwise you should complete the "deploy" folder with the built demo as compiled from the provided source files. Please note that the folder already contains a container html page, just as an example.<br>
This deploy folder is ready to be deployed under Lightstreamer's internal Web Server, by copying all the contents into some subfolder of the "pages" directory.

The demos are now ready to be launched.

## How to deploy the demo on your web server ##

By the current configuration, the demo tries to access Lightstreamer Server by using the protocol, hostname and port from which the "index.html" page was requested; in other words, the demo assumes that the static resources are deployed inside Lightstreamer Server.<br>

In order to deploy the demo static resources on an external Web Server, some changes are needed on the deployment image before or after copying it into the Web Server folders.
The configuration of the url to be used to connect to Lightstreamer Server should be added. The configuration section can be easily found in deploy/index.html, as the if-block containing the param name="initparams" pattern and can be modified manually, without the need for a recompilation.<br>

Then, in order to allow the page to get resources from a different server, the Web Server address has to be included in the "clientaccesspolicy" resource deployed under Lightstreamer Server. See the <silverlight_accesspolicy_enabled> element in the Server configuration file for details.

# See Also #

## Lightstreamer Adapters needed by this demo client ##

* [Lightstreamer StockList Demo Adapter](https://github.com/Weswit/Lightstreamer-example-Stocklist-adapter-java)
* [Lightstreamer Reusable Metadata Adapter in Java](https://github.com/Weswit/Lightstreamer-example-ReusableMetadata-adapter-java)

## Similar demo clients that may interest you ##

* [Lightstreamer StockList Demo Client for JavaScript](https://github.com/Weswit/Lightstreamer-example-Stocklist-client-javascript)
* [Lightstreamer StockList Demo Client for jQuery](https://github.com/Weswit/Lightstreamer-example-StockList-client-jquery)
* [Lightstreamer StockList Demo Client for Dojo](https://github.com/Weswit/Lightstreamer-example-StockList-client-dojo)
* [Lightstreamer StockList Demo Client for Adobe Flex SDK](https://github.com/Weswit/Lightstreamer-example-StockList-client-flex)
* [Lightstreamer StockList Demo Client for Java SE](https://github.com/Weswit/Lightstreamer-example-StockList-client-java)
* [Lightstreamer StockList Demo Client for .NET](https://github.com/Weswit/Lightstreamer-example-StockList-client-dotnet)

# Lightstreamer Compatibility Notes #

- Compatible with Lightstreamer Silverlight Client Library version 1.4 or newer.
- For Lightstreamer Allegro+, Presto, Vivace.