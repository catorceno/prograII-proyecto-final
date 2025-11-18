import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));

/*
1.command
ng generate environments

2.environment.development.ts
apiURL: 'http://...'

3.app.config.ts
providers: [... provideHttpClient(withFetch())]

4.
ng generate component menu
ng generate component landing
ng generate component indice-productos
ng generate component
ng generate component
ng generate component
*/
