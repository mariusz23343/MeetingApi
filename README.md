# MeetingApi
Recruitment Task for x-kom


WebApi application written in .net 5.0, using asp net web api and entity framework (in the code first approach). 
The API with the "MeetsControler" allows you to create a meeting at a given time, return a list of all meetings
and delete the meeting, and with the "ParticipantsController" it allows you to add a participant to a given meeting.
Communication between API and the client takes place through Data Transfer Objects


Database consists of two tables linked together in a one-to-many relationship.
Database created by mapping the base model by the migration engine.
