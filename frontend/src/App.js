import { Route, Routes, Navigate } from "react-router-dom";
import Main from "./components/Main/Main.jsx"
import AddRental from "./components/AddRental/AddRental.jsx";
import GetAllRentalPoints from "./components/GetAllRentalPoints/GetAllRentalPoints.jsx";
function App() {
  return (
    <Routes>
      <Route path="/AddRental" exact element={<AddRental />} />
      <Route path="/GetAllRentalPoints" exact element={<GetAllRentalPoints />} />
      <Route path="/Main" exact element={<Main />} />
    </Routes>
  );
}
export default App;