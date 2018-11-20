# WhisperMegagenial

User interface for megageniale

## First step

Run `npm install`.

Run  `npm install -g gulp`

Go to `cd semantic/`.

Run `gulp build`.

## Development server

Run `ng serve -c agent` for a dev server as an agent. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

Run `ng serve -c user --port=4201` for a dev server as an yser. Navigate to `http://localhost:4201/`. The app will automatically reload if you change any of the source files.

## Build


Run `ng build -c agent --output-path=dist/agent --base-href "/whisperui/agent/"` to build the project as agent.

Run `ng build -c user --output-path=dist/user --base-href "/whisperui/user/"` to build the project as user.
