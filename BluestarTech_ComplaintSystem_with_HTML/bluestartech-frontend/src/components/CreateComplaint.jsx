import React, { useState } from 'react'
export default function CreateComplaint({ apiBase }){
  const [customerId,setCustomerId]=useState('');
  const [title,setTitle]=useState('');
  const [description,setDescription]=useState('');
  const [areaId,setAreaId]=useState('');
  const [result,setResult]=useState(null);

  async function submit(e){
    e.preventDefault();
    const body = { customerId: Number(customerId), title, description, areaId: areaId?Number(areaId):null, category: 'CCTV' };
    const res = await fetch(`${apiBase}/api/complaints`,{ method:'POST', headers:{'Content-Type':'application/json'}, body: JSON.stringify(body) });
    const data = await res.json();
    setResult(data);
  }

  return (
    <div className="max-w-xl bg-white p-6 rounded-2xl shadow">
      <form onSubmit={submit} className="space-y-3">
        <input className="w-full p-2 border rounded" value={customerId} onChange={e=>setCustomerId(e.target.value)} placeholder="Customer ID" />
        <input className="w-full p-2 border rounded" value={title} onChange={e=>setTitle(e.target.value)} placeholder="Title" />
        <textarea className="w-full p-2 border rounded" value={description} onChange={e=>setDescription(e.target.value)} placeholder="Description" />
        <input className="w-full p-2 border rounded" value={areaId} onChange={e=>setAreaId(e.target.value)} placeholder="Area ID (optional)" />
        <button className="px-4 py-2 rounded bg-blue-600 text-white">Create</button>
      </form>

      {result && <pre className="mt-4 text-sm">{JSON.stringify(result,null,2)}</pre>}
    </div>
  )
}