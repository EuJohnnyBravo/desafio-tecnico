export interface Compositions {
  compositions: Composition[];
}

export interface Composition {
  id: number;
  foodCode: string;
  component: string;
  unit: string;
  valuePer100g: number;
  standardDeviation: number;
  minimumValue: number;
  maximumValue: number;
  numberOfDataUsed: number;
  reference: string;
  dataType: string;
}
