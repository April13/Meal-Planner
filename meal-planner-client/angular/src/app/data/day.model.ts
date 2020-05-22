import { Eat } from './eat.model';

/**
 * Represents the _Day_ model
 *
 * ```yaml
 * id: number;
 * accountId: number;
 * date: Date;
 * eats: Eat[];
 * ```
 */
export interface Day {
  id: number;
  accountId: number;
  date: Date;
  eats: Eat[];
}