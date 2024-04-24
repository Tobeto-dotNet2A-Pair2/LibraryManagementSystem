import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { getAppProviders } from './shared/providers/app-providers';

export const appConfig: ApplicationConfig = {
  providers: [getAppProviders()]
};
//test
