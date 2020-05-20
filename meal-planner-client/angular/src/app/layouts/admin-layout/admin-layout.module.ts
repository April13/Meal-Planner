import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AdminLayoutRoutes } from './admin-layout.routing';

import { DashboardComponent }       from '../../pages/dashboard/dashboard.component';
import { UserComponent }            from '../../pages/user/user.component';
import { TableComponent }           from '../../pages/table/table.component';
import { TypographyComponent }      from '../../pages/typography/typography.component';
import { IconsComponent }           from '../../pages/icons/icons.component';
import { NotificationsComponent }   from '../../pages/notifications/notifications.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RecipeComponent } from 'app/components/meal-planner/recipe/recipe.component';
import { GroceryListComponent } from 'app/components/meal-planner/grocery-list/grocery-list.component';
import { CalendarComponent } from 'app/components/meal-planner/calendar/calendar.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    NgbModule,
  ],
  declarations: [
    DashboardComponent,
    UserComponent,
    TableComponent,
    TypographyComponent,
    IconsComponent,
    NotificationsComponent,
    RecipeComponent,
    GroceryListComponent,
    CalendarComponent
  ]
})

export class AdminLayoutModule {}
