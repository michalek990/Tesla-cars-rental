import { useRef, useState } from "react";
import axios from "axios";
import { Link, useNavigate  } from "react-router-dom";
import styles from "./styles.module.css";

const AddRental = () => {
  let [data, setData] = useState({
    FirstName: "",
    Surname: "",
    PeselNumber: "",
    ContactNumber: 0,
    Nationality: "",
    Gender: "",
    RentalDateEnd: useRef(null),
    CarModel: "",
    StartRentalPointName: "",
    EndRentalPointName: ""
  });

  const [error, setError] = useState(null);
  const navigate = useNavigate();
  const handleChange = (event) => {
    const { name, value } = event.target;
    setData({ ...data, [name]: /^-?\d+$/.test(value) ? parseInt(value) : value });  };
  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const url = 'https://localhost:7267/api/rentals';
      console.log(data);
      const { data: res } = await axios.post(url, data);
      navigate('/');
    } catch (error) {
      console.log(error);
      if (error.response.data.status === 400) {
        console.log(data);
        setError("Check your input data");
      }
      else if(error.response.data.statusCode === 409){
        setError(error.response.data.details);
      }
      else if(error.response.data.statusCode === 404)
        setError(error.response.data.details);
      else if(error.response.data.statusCode === 500)
        setError(error.response.data.details);
    }
  };
  return (
    <div className={styles.signup_container}>  
      <div className={styles.signup_form_container}>
        <div className={styles.left}>
          <h1>Tesla cars rental</h1> 
            <Link to="/GetAllRentalPoints">
              <button type="button" className={styles.white_btn}>
                Zobacz nasze auta i placówki
              </button>
            </Link>
        </div>
        
        <div className={styles.right}>
          <form className={styles.form_container} onSubmit={handleSubmit}>
            <h1>Zarezerwuj auto już dzisiaj!</h1>
            <h3>Name</h3>
            <input
              type="text"
              placeholder="FirstName"
              name="FirstName"
              onChange={handleChange}
              value={data.FirstName}
              required
              className={styles.input}
            />
            <h3>Surname</h3>
            <input
              type="text"
              placeholder="Surname"
              name="Surname"
              onChange={handleChange}
              value={data.Surname}
              required
              className={styles.input}
            />
            <h3>Pesel number</h3>
            <input
              type="text"
              placeholder="PeselNumber"
              name="PeselNumber"
              onChange={handleChange}
              value={data.PeselNumber}
              required
              className={styles.input}
            />
            <h3>Contact Number</h3>
            <input
              type="number"
              placeholder="ContactNumber"
              name="ContactNumber"
              onChange={handleChange}
              value={data.ContactNumber}
              required
              className={styles.input}
            />
            <h3>Nationality</h3>
            <input
              type="text"
              placeholder="Nationality"
              name="Nationality"
              onChange={handleChange}
              value={data.Nationality}
              required
              className={styles.input}
            />

            <h3>Gender</h3>
            <input
              type="text"
              placeholder="Gender"
              name="Gender"
              onChange={handleChange}
              value={data.Gender}
              required
              className={styles.input}
            />

            <h3>Rental Date End</h3>
            <input
              type="date"
              placeholder="RentalDateEnd"
              name="RentalDateEnd"
              onChange={handleChange}
              value={data.RentalDateEnd}
              required
              className={styles.input}
            />
            <h3>Car model</h3>
            <input
              type="text"
              placeholder="CarModel"
              name="CarModel"
              onChange={handleChange}
              value={data.CarModel}
              required
              className={styles.input}
            />
            <h3>Start rental point name</h3>
            <input
              type="text"
              placeholder="StartRentalPointName"
              name="StartRentalPointName"
              onChange={handleChange}
              value={data.StartRentalPointName}
              required
              className={styles.input}
            />
            <h3>End rental point name</h3>
            <input
              type="text"
              placeholder="EndRentalPointName"
              name="EndRentalPointName"
              onChange={handleChange}
              value={data.EndRentalPointName}
              required
              className={styles.input}
            />
            {error && <div className={styles.error_msg}>{error}</div>}
            <button type="submit" className={styles.green_btn} onSubmit={handleSubmit}>
              Rezerwuj
            </button>
          </form>

          
        </div>
      </div>
    </div>
  );
};
export default AddRental;
