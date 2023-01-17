import { render, screen } from '@testing-library/react'
import Home from '@/pages/index'

describe('Home', () => {
  it('renders a heading', () => {
    render(<Home stories={[]} />)

    const heading = screen.getByRole('heading', {
      name: /Welcome to RobertLynJA\.com/i,
    })

    expect(heading).toBeInTheDocument()
  })
})
