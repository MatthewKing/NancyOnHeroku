Nancy on Heroku
===============

This repository serves as a simple guide to getting [Nancy](http://nancyfx.org/) up and running on [Heroku](https://heroku.com/).

Instructions
------------

1) Pull down this repository (or, of course, create your own NancyFx project)

```
$ git clone https://github.com/MatthewKing/NancyOnHeroku.git
```

2) [Create a Heroku account](https://signup.heroku.com/) and [download the Heroku Toolbelt](https://toolbelt.heroku.com/)

3) Log in to Heroku.

```
$ heroku login
```

4) From the application directory, create our Heroku application. We'll use [Michael Friis' excellent Heroku buildpack](https://github.com/friism/heroku-buildpack-mono/), which tells Heroku how to get Mono, pull down NuGet packages, compile a C# solution, etc.

```
$ heroku create appname --buildpack https://github.com/friism/heroku-buildpack-mono/
```
(where `appname` is whatever you want to call your app, of course).

5) Push the repository to Heroku.

```
$ git push heroku master
```

**If all went well, your app should now be happily up and running on Heroku!**

Notes
-----

* The self-hosted Nancy app needs to listen on the port specified in the PORT environment variable.
* While debugging, it's easier just to let the app run until ENTER is pressed, but when running as a daemon in production this will cause it to terminate instantly, so we'll require the user type 'quit'.
* If using the Razor view engine, the default Nancy.ViewEngines.Razor package will include some post-build steps that won't run on Heroku, as they are somewhat windows specific. You could remove them completely, but my preference is to remove the `if $(ConfigurationName) == Debug (` command and move the condition to the PostBuildEvent element: `<PostBuildEvent Condition=" '$(Configuration)' == 'Debug' ">`. See `NancyOnHeroku.csproj` for an example.

Copyright
---------
Copyright Matthew King 2014.

License
-------
This work is licensed under the MIT License. Refer to license.txt for more information.
