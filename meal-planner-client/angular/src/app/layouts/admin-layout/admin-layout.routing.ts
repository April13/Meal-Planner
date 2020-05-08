import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { UserComponent } from '../../pages/user/user.component';
import { TableComponent } from '../../pages/table/table.component';
import { TypographyComponent } from '../../pages/typography/typography.component';
import { IconsComponent } from '../../pages/icons/icons.component';
import { NotificationsComponent } from '../../pages/notifications/notifications.component';
import { GroceryListComponent } from 'app/modules/meal-planner/grocery-list/grocery-list.component';
import { RecipeComponent } from 'app/modules/meal-planner/recipe/recipe.component';
import { CalendarComponent } from 'app/modules/meal-planner/calendar/calendar.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard',      component: DashboardComponent },
    { path: 'user',           component: UserComponent },
    { path: 'table',          component: TableComponent },
    { path: 'typography',     component: TypographyComponent },
    { path: 'icons',          component: IconsComponent },
    { path: 'notifications',  component: NotificationsComponent },
    { path: 'calendar',       component: CalendarComponent },
    { path: 'recipe',         component: RecipeComponent },
    { path: 'grocery-list',   component: GroceryListComponent }
];
