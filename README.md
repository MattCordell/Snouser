# Snouser
This is a basic client to demonstrate the functionality of the NCTS terminology syndication service.
It was developed during the third NCTS connectathon, hosted by the Australian Digital Health Agency on July 5+6 2016.

The code includes a class for the syndication methods, and a basic application to demonstrate updates.
The application consists of a search screen, with details of the current SNOMED CT version in use.
Updates are through a single click - and involve downloading RF2 deltas and patching these to the applications database.
Updates can be incremental or absolute.

Unfortunately I didn't get to demonstrate it to very literal last moment technical issues... But the application functions as intended.
Possible improvements (if touched again :) ):
* Implement Full text index ranking (and customised).
* Authentication of content downloads. (Highly likely at future connectathon).

The current code relies on being seeded with a "FULL" SNOMED CT release for initialising (see code).
The syndication feed referenced is not currently publicly accessible.

There's certainly room for improvement in the quality of the code too – almost no validation or exception handling. But this is a disposable proof of concept project.
