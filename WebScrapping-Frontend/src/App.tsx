import { BrowserRouter, Route, Routes } from 'react-router';
import Home from './pages/home/home';
import FoodComposition from './pages/foodComposition/foodComposition';

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/food/:code" element={<FoodComposition />} />
      </Routes>
    </BrowserRouter>
  );
}
