import axios from 'axios'
import Vue from 'vue'
import moment from 'moment'

Vue.prototype.$http = axios


const baseURL = 'https://localhost:44318'


const handleError = fn => (...params) =>
  fn(...params).catch((error) => {
    console.log(error)
  })

export const api = {
  baseURL,
  saveUser (user) {
    window.localStorage.setItem(
      'user',
      JSON.stringify(user)
    )
  },

  getUser () {
    return JSON.parse(localStorage.getItem('user'))
  },
  getTimestamp () {
    return (new Date()).getTime()
  },
 
  formateDate (value) {
    if (value) {
      return moment(String(value)).format('DD-MM-YYYY hh:mm')
    }
  },

  async getRights () {
    try {
      const res = await axios.get(baseURL + '/api/users/rights?path=' + document.location.pathname)
      return res.data
    } catch (err) {
      console.log(err)
    }
  },
  timeSince (date) {
    date = new Date(date)
    const seconds = Math.floor((new Date() - date) / 1000)

    let interval = Math.floor(seconds / 31536000)

    if (interval > 1) {
      return interval + ' years'
    }
    interval = Math.floor(seconds / 2592000)
    if (interval > 1) {
      return interval + ' months'
    }
    interval = Math.floor(seconds / 86400)
    if (interval > 1) {
      return interval + ' days'
    }
    interval = Math.floor(seconds / 3600)
    if (interval > 1) {
      return interval + ' hours'
    }
    interval = Math.floor(seconds / 60)
    if (interval > 1) {
      return interval + ' minutes'
    }

    if (isNaN(seconds)) { return 'NA' }
    return Math.floor(seconds) + ' seconds'
  },
  getage (birthday) {
    if (birthday) {
      const ageDifMs = Date.now() - birthday.getTime()
      const ageDate = new Date(ageDifMs) // miliseconds from epoch
      return Math.abs(ageDate.getUTCFullYear() - 1970)
    }
    return 'Not Available'
  },
  GetParameters (filters) {
    try {
      let parameters = ''

      Object.entries(filters).forEach((entry) => {
        const [key, value] = entry
        if (value != null) { parameters = parameters + key + '=' + value + '&' }
      })

      return parameters.substring(0, parameters.length - 1)
    } catch (err) {
      console.log(err)
    }
    return ''
  },
  sort (value, list) {
    list.sort((a, b) => (a[value] > b[value]) ? 1 : ((b[value] > a[value]) ? -1 : 0))
    return list
  },
  sortdsc (value, list) {
    list.sort((a, b) => (a[value] < b[value]) ? 1 : ((b[value] < a[value]) ? -1 : 0))
    return list
  },
  localSearch (value, list) {
    const results = []
    if (value === '') { return list } else {
      value = value.toLowerCase()
      for (let i = 0; i < list.length; i++) {
        const str = JSON.stringify(list[i])
        if (str.toLowerCase().includes(value)) {
          results.push(list[i])
        }
      }
      return results
    }
  },
  getFilterList (value, list) {
    return [...new Set(list.map(item => item[value]))]
  },
  localFilter (value, list, exact = false) {
    const results = []
    value = value.toLowerCase()
    if (value === '') { return list } else {
      if (exact) { value = '"' + value + '"' }
      for (let i = 0; i < list.length; i++) {
        const str = JSON.stringify(list[i])
        if (str.toLowerCase().includes(value)) {
          results.push(list[i])
        }
      }
      return results
    }
  },

 
  getFrom: handleError(async (path) => {
    const res = await axios.get(path)
    return res.data
  }),
  get: handleError(async (path) => {
    const res = await axios.get(baseURL + path)
    return res.data
  }),
  post: handleError(async (path, payload) => {
    const res = await axios.post(baseURL + path, payload)
    return res.data
  }),
  put: handleError(async (path, payload) => {
    const res = await axios.put(baseURL + path, payload)
    return res.data
  }),
  delete: handleError(async (path, payload) => {
    const res = await axios.delete(baseURL + path, payload)
    return res.data
  }),
  getitem: handleError(async (table, id) => {
    const res = await axios.get(baseURL + '/g/' + table + '/' + id)
    return res.data
  }),

  getitems: handleError(async (table) => {
    const res = await axios.get(baseURL + '/g/' + table)
    return res.data
  }),
  countitems: handleError(async (table, id) => {
    const res = await axios.get(baseURL + '/g/' + table + '/' + id)
    return res.data
  }),
  deleteitem: handleError(async (table, id) => {
    const res = await axios.delete(baseURL + '/g/' + table + '/' + id)
    return res.data
  }),
  createitem: handleError(async (table, payload) => {
    const res = await axios.post(baseURL + '/g/' + table, payload)
    return res.data
  }),
  updateitem: handleError(async (table, payload) => {
    const res = await axios.put(baseURL + '/g/' + table + '/' + payload._id, payload)
    return res.data
  })
}
