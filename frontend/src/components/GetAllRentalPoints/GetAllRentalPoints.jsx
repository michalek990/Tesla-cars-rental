import styles from "../GetAllRentalPoints/styles.module.css";
import { Link, useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";
import Table from "react-bootstrap/Table";
import { Button, Container, Form } from "react-bootstrap";

const GetAllRentalPoints = () => {

  const [data, setData] = useState([]);
  const [error, setError] = useState(null);
  const navigate = useNavigate();
  const [car, setCar] = useState();

  const getAllCars= async() => {
    try{
      return await axios.get('https://localhost:7267/api/cars/all-cars?PageSize=100')
    }catch(err){
      return err.message;
    }
  }

  const getCars = async () => {
    try {
      const result = await getAllCars();
      setCar(result.data.data);
      console.log(result.data.data);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    getCars();
  },[]);

 
  
  return (
    <div className={styles.main_container}>
      <nav className={styles.navbar}>
        <h1>Tesla cars rental </h1>
        <div className={styles.buttons}>
        <Link to="/AddRental">
          <button type="button" className={styles.white_btn}>
            Nowa rezerwacja
          </button>
        </Link>
        <Link to="/">
          <button type="button" className={styles.white_btn}>
            Strona główna
          </button>
        </Link>
        </div>
      </nav>


      <div className={styles.text}>Dostępne auta</div>
      <>
        <Table  striped bordered hover className={styles.cars}>
          <thead className="thead-dark">
            <tr>
              <th scope="col">Model</th>
              <th scope="col">Horse power</th>
              <th scope="col">Vin</th>
              <th scope="col">Year of production</th>
              <th scope="col">Available</th>
              <th scope="col">Cost per day</th>
              <th scope="col">Location</th>
            </tr>
          </thead>
          <tbody className="table-striped">{car ? car.map((item) => (
                  <tr key={item.model}>
                    <td>{item.model}</td>
                    <td>{item.horsePower}</td>
                    <td>{item.vin}</td>
                    <td>{item.yearOfProduction}</td>
                    <td>{item.available === false ? "Zajęty":"Dostępny"}</td>
                    <td>{item.costPerDay}$</td>
                    <td>{item.rentalPointId === 1 ? 'Palma AirPort' : 
                    item.rentalPointId === 2 ? 'Palma City Center' : 
                    item.rentalPointId === 3 ? 'Alcudia' : 
                    item.rentalPointId === 4 ? 'Manacor' : 'Nieznane'}</td>
                  </tr>
                ))
              :<tr></tr>}
          </tbody>
        </Table>
    </>
    </div>
  );
};
export default GetAllRentalPoints;
