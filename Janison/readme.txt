Application Architecture
========================

No .NET Core used.

Built using AngularJS, Bootstrap, C#, MVC, Web API, Entity Framework, LINQ and a local SQL Express instance.

http://angular-ui.github.io/bootstrap/ - Bootstrap components for AngularJS by the AngularUI Team

jQuery included, but might not be needed depending on bootstrap functionality desired.
jQuery Lite is included with AngularJS.
If full jQuery is needed, DOM munipulations (selectors) should be done in Directives not Controllers.

Dates are stored in universal time (UTC) to accomodate global indepedence from time zones - dates are formated to local time zone for display.  A custom filter was created to bring more readability/meaning to dates - can be seen on Course Detail page (modules.cshtml), DateCreated and DateModified now show english words.

A third party loading bar is used to show progress for restful $http requests.

UI-router is used for Nesting and Statefullness beyond what ngRouter can provide.

Sorting and Paging is performed client-side using AngularJS's OrderBy and LimitTo filters.  

Primary keys where used for both CourseID and ModuleID, a foreign key on Module for CourseID was Indexed for join performance.

Web.Config AppSettings have a API_URL key to easily enable the WebAPI to be moved into a seperate CORS enabled project for location on a different web server - for scalability.

Assumptions
===========

- Assumed that 'course modified date' needed to be updated when Modules where added to a Course.
- When a Course is deleted the associated Modules are also removed.
- Only english speaking countries.
- Australian date formats.
- For PC and Tablet use, user experience degraded a little on mobile - but workable.
- Small dataset sizes (relative to current platform and device hardware usage stats) - i.e. Sorting and Paging done on client-side, might need moving server-side.
- Not much client-side Date Object minipulations currently needed, otherwise recommend moment.js or similar utility.
- Not much client-side Object Array minipulation needed, otherwise recommend Lodash/Underscore.js or similar utility.
- Probably the biggest assumption was that you you'd prefer it to be created in the technologies currently in use at Janison.