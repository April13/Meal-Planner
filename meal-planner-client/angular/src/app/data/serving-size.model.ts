import { Amount } from './amount.model';

/**
 * Represents the _Serving Size_ model
 *
 * ```yaml
 * unitPerServingId?: number;
 * itemName: string;
 * servingSize: Amount;
 * ```
 */
export interface ServingSize {
  unitPerServingId?: number;
  itemName: string;
  servingSize: Amount;
}