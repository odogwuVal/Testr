# Testr
A comprehensive technical screening and evaluation application.


### Overview
Testr is designed to be able to accommodate registration of candidates who can then apply for a cohort of The Bulb Africa Fellowship anytime applications are open. Applicants can then take the required entry exam and be graded as part of the application requirements right in the same app. Candidates can also view their application status that can be changed by admins (staff of The Bulb Africa) at the backend. Upon a change in the application status of an applicant, an email notification is sent to applicants. 


### Current features
- A candidate can create an account and fill out a profile.
- Candidates can view *ONLY* *THEIR* profiles and no other candidate's.
- Administrators can log into their accounts.
- Administrators can view all registered candidates' profiles.
- Candidates can reset their passwords.
- Cohort cycle creation so Administrators can create new cohort cycles.
- Bulk and single email feature so Administrators can send emails to all applicants.


### Upcoming features

- Cohort cycle application so Candidates can apply.
- Application status change so Administrators can change application status of applicants.
- Push notifications for change in application status so Candidates can receive notifications when there is a change in their application status.
- Applications received presentation so Administrators can view all applications received.
- Test questions upload so Administrators can upload test questions (and answers) per track so applicants can take their exams.
- Exam feature so Candidates can take the exams for their respective tracks.



### Endpoints

| Endpoint URL  | Method        | Functionality|
| ------------- | ------------- |------------- |
| ADMINISTRATORS|               |              |
| /Administrators/register-admin  | POST  | Register a new admin |
| AUTHENTICATION|              |               |
| /Authentication/login  | POST  | Sign in a registered user |
| CANDIDATES|
| /Candiates/register  | POST  | Regiser as a new candidate |
| /Candiates  | GET  | Fetch all registered candidates |
| /Candiates:Id  | GET  | Fetch a specified candiate |
| ACCOUNT|
| /Account/forgot-password | POST  | initiate the password reset process |
| /Account/reset-password | POST  | Send the password reset email to user |
| CYCLES|
| /Cycles | POST  | Create a new cycle |
| /Cycles | GET  | Fetch all cycles |
| /Cycles:id | GET  | Fetch a specified cycle |
| Email|
| /email/single-email-send | POST  | Send a single email |
| /email/bulk-email-send | POST  | Send a bulk email |





### Built with

* Primary language: C#
* Server technology: ASP.Net Core
* Database system: Microsoft SQL Server
* ORM: Entity Framework Core

### License


