import React from 'react';
import GlassCard from '../components/GlassCard';
import './glassmorphism.css';

const AboutPage: React.FC = () => {
    return (
        <div className="about-page">
            <GlassCard>
                <h1>About This Project</h1>
                <p>
                    This is a full-stack mini project built using React, PostgreSQL, and ASP.NET. 
                    The application showcases a glassmorphism design with rounded corners and padding, 
                    providing a modern and visually appealing user interface.
                </p>
                <p>
                    The project is structured to separate concerns, with dedicated components for the header, footer, 
                    and content display. The Montserrat font is used throughout the application for a clean and 
                    professional look.
                </p>
            </GlassCard>
        </div>
    );
};

export default AboutPage;