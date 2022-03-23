export const visuals = {
  ShowError (res) {
    try {
      const elem = document.querySelector('.error-alert')
      if (elem != null) { elem.parentNode.removeChild(elem) }

      const node = document.createElement('div')
      const text = document.createTextNode(res.message)
      node.appendChild(text)
      node.classList.add('error-alert')
      node.classList.add('alert')
      node.classList.add('alert-danger')
      node.classList.add('text-center')
      node.classList.add('mt-3')

      const form = document.getElementById('main-form')
      form.appendChild(node)
    } catch (err) {
      console.log(err)
      if (res != null && res.message) {
        alert(res.message)
      } else {
        alert('An unknown error occured while trying to submit your request, please try again later')
      }
    }
  },
  IsError (res) {
    return res._id === undefined || res.error === true
  },
  StartLoader (id) {
    const loader = document.createElement('div')
    loader.innerHTML = '<div class="loader loader-lg loader-primary loader-middleware text-center py-5"> <span class="spinner-grow spinner-grow-sm"></span> </div>'
    const app = document.getElementById(id)
    if (app) {
      app.style.display = 'none'
      loader.setAttribute('id', id + '-loader')
      loader.style.width = '100%'
      app.parentElement.appendChild(loader)
    }
  },
  StopLoader (id) {
    const loader = document.getElementById(id + '-loader')
    if (loader) { loader.remove() }
    const app = document.getElementById(id)
    if (app) { app.style.display = 'block' }
  },
  StartSmallLoader (id) {
    const loader = document.createElement('div')
    loader.innerHTML = '<button class="btn btn-primary btn-block" type="button" disabled><span class="spinner-grow spinner-grow-sm"></span> Loading...</button>'

    const app = document.getElementById(id)
    if (app) {
      app.style.display = 'none'
      loader.setAttribute('id', id + '-loader')
      app.parentElement.appendChild(loader)
    }
  },
  StopSmallLoader (id) {
    const loader = document.getElementById(id + '-loader')
    if (loader) { loader.remove() }
    const app = document.getElementById(id)
    if (app) { app.style.display = 'block' }
  },

  ShowSuccess (res) {
    const elem = document.querySelector('.error-alert')
    if (elem != null) { elem.parentNode.removeChild(elem) }

    const node = document.createElement('div')
    const text = document.createTextNode(res.message)
    node.appendChild(text)
    node.classList.add('error-alert')
    node.classList.add('alert')
    node.classList.add('alert-success')
    node.classList.add('text-center')
    node.classList.add('mt-3')

    const form = document.getElementById('main-form')
    form.appendChild(node)
  }
}
