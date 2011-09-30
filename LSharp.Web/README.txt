An HttpHandler which calls LSharp

Scripting web applications using LSharp has been a frequently requested feature; now
we have a solution.

Create a new ASP.NET web application project.
Change the web.config to include the following within <system.web>:

		<httpHandlers>
			<add verb="*" path="*.lsp" type="LSharp.Web.LSharpHttpHandler,LSharp.Web"/>
		</httpHandlers>

Then copy LSharp.dll and LSharp.Web.dll into the bin directory of the web application.

Then write your LSharp Page as a text file with a *.lsp extension.

That's it, except to say that *content* is bound to the http context; you also have 
access to *response* *request* *session* and *application*

Here is a simple example

(write *response* "<h1>Hello World</h1> <p> Rob </p>")

See LSharp.Web.Tests for an example included with the LSharp source distribution.

Thanks to to Ted Neward for his pointers on how to do this at DevWeek 2006.
Rob Blackwell
Feb 2006






