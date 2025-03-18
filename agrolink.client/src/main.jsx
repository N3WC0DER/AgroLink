import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import Welcome from './Welcome.jsx'
import Home from './Home.jsx'

createRoot(document.getElementById('root')).render(
    <StrictMode>
        <Router>
            <Routes>
                <Route index path="/" element={<Welcome />} />
                <Route path="/home" element={<Home />} />
                <Route path="*" element={<Navigate to="/" replace />} />
            </Routes>
        </Router>
    </StrictMode>,
)
