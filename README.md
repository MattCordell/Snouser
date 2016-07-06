# Snouser
This is a basic client to demonstrate the functionality of the NCTS terminology syndication service.
It was developed during the third NCTS connectathon, hosted by the Australian Digital Health Agency on July 5+6 2016.

The code includes a class for the synidcation methods, and a basic application to demonstrate updates.
The application consists of a search screen, with details of the current SNOMED CT version in use.
Updates are through a single click - and involve downloading RF2 deltas and patching these to the applications database.
Updates can be incremental or absolute.

Unfortuneately I didn't get to demonstrate it to to very litteral last moment technical issues... But the application functions as intended.
possible improvements (if touched again :) ):
* implement Full text index ranking (and cusomtised).
* authentication of content downloads. (highly likely at future connectathon).

The current code relies on being seeded with a "FULL" SNOMED CT release for initialising (see code).
The syndication feed referenced is not currently publicly accessible.

There's certainly room for improvement in the quality of the code too. But this is a disposeable proof of concept project.
