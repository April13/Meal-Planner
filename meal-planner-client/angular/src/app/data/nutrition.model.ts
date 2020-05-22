import { Nutrient } from './nutrient.model';
import { ServingSize } from './serving-size.model';

/**
 * Represents the _Nutrition_ model
 *
 * ```yaml
 * caloriesPerServing: number;
 * servingsPerContainer: number;
 * servingSizes: ServingSize[];
 * nutrients: Nutrient[];
 * ```
 */
export interface Nutrition {
  caloriesPerServing: number;
  servingsPerContainer: number;
  servingSizes: ServingSize[];
  nutrients: Nutrient[];
}