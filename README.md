# LearningManagement

Learning Management Dashboard as part of a Candidate Assignment

## Setup instructions
- Clone/download the git repo
- Make sure ports 5019 and 7209 are free or change the port in `Properties/launchSettings.json`, and the `API_BASE` at `Frontend/script.js`
- Use Visual Studio to run as Debug or Release.

## Overview of architecture and design decisions
This project is being served by .NET Core 8.0 (long term support) RESTful API as the backend.  
A simple GUI consisting of a single HTML page with scripts for using the API.  
And CSS to make it look decent.  
I have added some dummy data to showcase the basics of the Dashboard from the get-go.

## Any trade-offs made or areas for improvement
I designed the project as a single .dll runnable instead of separating the structure into several class/project files, which might make it more sustainable in a service-run environment but for the simplicity of this task, I preferred to keep it all in one project.  
The GUI is very simplistic and could be much more rich with features and feedback/animations, but again for the sake of simplicity I kept it to a minimum.
