import { ServingSize } from './serving-size.model';

/**
 * Represents the _Eat_ model
 *
 * ```yaml
 * servings: ServingSize;
 * foodId: number;
 * ```
 */
export interface Eat {
  servings: ServingSize;
  foodId: number;
}