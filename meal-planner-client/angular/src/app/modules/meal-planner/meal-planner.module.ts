import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FoodComponent } from './food/food.component';
import { RecipeComponent } from './recipe/recipe.component';
import { GroceryListComponent } from './grocery-list/grocery-list.component';
import { CalendarComponent } from './calendar/calendar.component';

@NgModule({
  declarations: [FoodComponent, RecipeComponent, GroceryListComponent, CalendarComponent],
  imports: [
    CommonModule
  ]
})
export class MealPlannerModule { }
