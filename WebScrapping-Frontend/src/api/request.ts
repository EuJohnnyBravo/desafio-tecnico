import axios from 'axios';
import { AllFoods, Food } from '../types/foods';
import { Composition, Compositions } from '../types/foodComposition';

export const api = axios.create({
  baseURL: 'http://localhost:5007/api',
  headers: {
    'Content-Type': 'application/json',
  },
});

export const postFoods = async (): Promise<number> => {
  try {
    const response = await api.post('/food/');
    return response.status;
  } catch (error) {
    console.error(error);
    throw error;
  }
};

export const getFoodByCode = async (code: string): Promise<Food> => {
  try {
    const response = await api.get<Food>(`/food/code/${code}`);
    return response.data;
  } catch (error) {
    console.error(error);
    throw error;
  }
};

export const postFoodComposition = async (code: string): Promise<number> => {
  try {
    const response = await api.post(`/foodComposition/code/${code}`);
    return response.status;
  } catch (error) {
    console.error(error);
    throw error;
  }
};

export const getFoods = async (): Promise<Food[]> => {
  try {
    const response = await api.get<AllFoods>('/food/');
    return response.data.foods;
  } catch (error) {
    console.error(error);
    throw error;
  }
};

export const getFoodComposition = async (
  code: string,
): Promise<Composition[]> => {
  try {
    const response = await api.get<Compositions>(
      `/foodComposition/code/${code}`,
    );
    return response.data.compositions;
  } catch (error) {
    console.error(error);
    throw error;
  }
};
