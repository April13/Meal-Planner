import { Link } from './link.model';

/**
 * Represents the _Config_ model
 *
 * ```yaml
 * api: object;
 * navigation: object;
 * ```
 */
export interface Config {
  api: {
    account: string;
    day: string;
    food: string;
    nutrientType: string;
    unit: string;
  };
  navigation: {
    footer: Link[];
    header: Link[];
  };
}