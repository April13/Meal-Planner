import { Nutrition } from './nutrition.model';

/**
 * Represents the _Food_ model
 *
 * ```yaml
 * id: number;
 * accountId: number;
 * name: string;
 * nutrition: Nutrition;
 * ```
 */
export interface Food {
  id: number;
  accountId: number;
  name: string;
  nutrition: Nutrition;
}