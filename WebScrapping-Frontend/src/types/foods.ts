export interface AllFoods {
  foods: Food[];
}

export interface Food {
  code: string;
  name: string;
  scientificName: string;
  group: string;
}
