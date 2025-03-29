import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import TableCalendar from 'react-calendar';
import 'react-calendar/dist/Calendar.css';
import { format } from 'date-fns';
import Domain from '../constants/Domain';

const Appointment = () => {
  const { doctorId } = useParams();
  const [currentDay, setCurrentDay] = useState(new Date());
  const [timeSelected, setTimeSelected] = useState(false);
  const [currentIndex, setCurrentIndex] = useState(null);
  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const handleDayClick = (day) => {
    setCurrentDay(day);
    setTimeSelected(false); 
  };
  
  const handleTimeSelect = (index) => {
    setCurrentIndex(index);
    setTimeSelected(true);
  };

  const handleAppointment = async () => {
    setIsLoading(true);
    setError(null);
    const appointmentDate = format(currentDay, 'yyyy-MM-dd') + 'T' + (currentIndex + 9) + ':00:00';
    const url = `${Domain.resoureseUrl()}/api/Appointment`;

    try {
      const response = await fetch(url, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          DoctorId: doctorId,
          PatientId: "71c7d19b-93ef-42de-a43c-7a2178dd6d48", 
          AppointmentDate: appointmentDate,
        }),
      });

      if (response.ok) {
        const responseData = await response.json();
        navigate(`/success`, { state: responseData }); 
      } else {
        const errorData = await response.json();
        setError(`Error: ${errorData.message || 'Failed to book appointment'}`);
      }
    } catch (err) {
      setError(`Error: ${err.message}`);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-100 p-5 " >
      <div className="bg-white shadow-lg rounded-xl p-24 w-full max-w-8xl">
        
        <h1 className="text-3xl font-semibold text-center text-blue-700 mb-6">
          Book an Appointment
        </h1>

        {/* Calendar Section */}
        <div className="flex justify-center mb-5 ">
          <TableCalendar
            onChange={handleDayClick}
            value={currentDay}
            className="border rounded-lg p-3 shadow-sm"
          />
        </div>

        {/* Time Slots */}
        <h2 className="text-lg font-semibold mb-2 text-gray-700">Select a Time:</h2>
        <div className="grid grid-cols-4 gap-4">
          {[...Array(8)].map((_, index) => (
            <button
              key={index}
              onClick={() => handleTimeSelect(index)}
              className={`flex items-center justify-center h-12 rounded-lg cursor-pointer transition 
                ${currentIndex === index ? 'bg-blue-600 text-white' : 'bg-gray-200 text-gray-700 hover:bg-blue-500 hover:text-white'}`}
            >
              {index + 9}:00 {index + 9 >= 12 ? 'PM' : 'AM'}
            </button>
          ))}
        </div>

        {/* Error Message */}
        {error && <p className="text-red-500 text-center mt-3">{error}</p>}

        {/* Submit Button */}
        <div className="flex justify-center mt-6">
          <button
            onClick={handleAppointment}
            disabled={!timeSelected || isLoading}
            className="w-full bg-blue-600 text-white py-3 rounded-lg font-semibold text-lg 
                       hover:bg-blue-700 transition duration-300 disabled:opacity-50"
          >
            {isLoading ? 'Submitting...' : 'Confirm Appointment'}
          </button>
        </div>
      </div>
    </div>
  );
};

export default Appointment;
