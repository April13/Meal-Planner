import { Amount } from './amount.model';

/**
 * Represents the _Nutrient_ model
 *
 * ```yaml
 * nutrientTypeId: number;
 * dailyValuePercentage?: number;
 * amount: Amount;
 * ```
 */
export interface Nutrient {
  nutrientTypeId: number;
  dailyValuePercentage?: number;
  amount: Amount;
}