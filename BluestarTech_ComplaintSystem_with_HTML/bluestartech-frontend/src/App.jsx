import React from 'react'
import CreateComplaint from './components/CreateComplaint'

export default function App(){
  return (
    <div className="min-h-screen bg-gray-100 p-6">
      <h1 className="text-2xl font-bold mb-4">Bluestar Tech — Complaint Portal</h1>
      <CreateComplaint apiBase={import.meta.env.VITE_API_BASE || 'http://localhost:5000'} />
    </div>
  )
}