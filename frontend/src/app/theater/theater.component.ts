import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TheaterInfo } from '../models/theater.models';
import { SeatingPlan } from '../models/seating-plan.models';
import { SeatingPlanComponent } from "../seating-plan/seating-plan.component";
import { SeatingPlanService } from '../seating-plan.service';

@Component({
  selector: 'app-theater',
  imports: [CommonModule, SeatingPlanComponent],
  templateUrl: './theater.component.html',
  styleUrl: './theater.component.css'
})
export class TheaterComponent {
  // theater?: TheaterInfo;

  constructor(){
  }
}
