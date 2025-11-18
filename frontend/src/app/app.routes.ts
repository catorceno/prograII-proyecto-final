import { Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { TheaterComponent } from './theater/theater.component';

export const routes: Routes = [
    {
        path: '',
        component: LandingComponent
    },
    {
        path: 'theater',
        component: TheaterComponent
    }
];
