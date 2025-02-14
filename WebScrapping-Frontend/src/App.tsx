import { Suspense, lazy } from 'react';
import { BrowserRouter, Route, Routes } from 'react-router';
import { LoadingIndicator } from './components/loadingIndicator';

const Home = lazy(() => import('./pages/home/home'));
const FoodComposition = lazy(
  () => import('./pages/foodComposition/foodComposition'),
);

export default function App() {
  return (
    <BrowserRouter>
      <Suspense
        fallback={
          <div className="flex items-center justify-center">
            <LoadingIndicator />
          </div>
        }
      >
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/food/:code" element={<FoodComposition />} />
        </Routes>
      </Suspense>
    </BrowserRouter>
  );
}
