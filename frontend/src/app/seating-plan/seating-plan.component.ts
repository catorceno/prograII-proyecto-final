import { Component, inject, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SeatingPlan } from '../models/seating-plan.models';
import { SeatingPlanService } from '../seating-plan.service';

@Component({
  selector: 'app-seating-plan',
  imports: [CommonModule],
  templateUrl: './seating-plan.component.html',
  styleUrl: './seating-plan.component.css'
})
export class SeatingPlanComponent {
  // @Input() id: number;
  
  seatingPlanService = inject(SeatingPlanService);
  seatingPlan?: SeatingPlan;

  constructor(){
    this.seatingPlanService.getByTheaterId(1).subscribe(seatingPlan => {
      this.seatingPlan = seatingPlan;
    });
  }
}
