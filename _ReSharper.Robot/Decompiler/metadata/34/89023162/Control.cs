// Type: System.Windows.Forms.Control
// Assembly: System.Windows.Forms, Version=3.5.0.0, Culture=neutral, PublicKeyToken=969db8053d3322ac
// Assembly location: c:\Program Files (x86)\Microsoft.NET\SDK\CompactFramework\v3.5\WindowsCE\System.Windows.Forms.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms.Layout;

namespace System.Windows.Forms
{
  public class Control : Component, IBindableComponent, IComponent, IDisposable
  {
    protected virtual Rectangle GetScaledBounds(Rectangle bounds, SizeF factor, BoundsSpecified specified);
    protected virtual void OnBindingContextChanged(EventArgs e);
    public bool Focus();
    public void Show();
    public void Hide();
    public void Invalidate();
    public void Invalidate(Rectangle rectangle);
    public virtual void Refresh();
    public void Update();
    public void BringToFront();
    public void SendToBack();
    public Point PointToScreen(Point p);
    public Rectangle RectangleToScreen(Rectangle r);
    public Rectangle RectangleToClient(Rectangle r);
    public Point PointToClient(Point p);
    public Graphics CreateGraphics();
    protected override void Dispose(bool disposing);
    public object Invoke(Delegate method);
    public object Invoke(Delegate method, params object[] args);
    public IAsyncResult BeginInvoke(Delegate method);
    public IAsyncResult BeginInvoke(Delegate method, params object[] args);
    public object EndInvoke(IAsyncResult asyncResult);
    public bool SelectNextControl(Control ctl, bool forward, bool tabStopOnly, bool nested, bool wrap);
    protected virtual void OnPaint(PaintEventArgs e);
    protected virtual void OnPaintBackground(PaintEventArgs e);
    protected virtual void OnMouseDown(MouseEventArgs e);
    protected virtual void OnMouseUp(MouseEventArgs e);
    protected virtual void OnMouseMove(MouseEventArgs e);
    protected virtual void OnKeyDown(KeyEventArgs e);
    protected virtual void OnKeyPress(KeyPressEventArgs e);
    protected virtual void OnKeyUp(KeyEventArgs e);
    protected virtual void OnClick(EventArgs e);
    protected virtual void OnDoubleClick(EventArgs e);
    protected virtual void OnResize(EventArgs e);
    protected virtual void OnEnabledChanged(EventArgs e);
    protected virtual void OnTextChanged(EventArgs e);
    protected virtual void OnParentChanged(EventArgs e);
    protected virtual void OnGotFocus(EventArgs e);
    protected virtual void OnLostFocus(EventArgs e);
    protected virtual void OnHelpRequested(HelpEventArgs e);
    protected virtual void OnHandleCreated(EventArgs e);
    protected virtual void OnHandleDestroyed(EventArgs e);
    protected virtual void ScaleControl(SizeF factor, BoundsSpecified specified);
    public void ResumeLayout();
    public void ResumeLayout(bool performLayout);
    public void SuspendLayout();
    public void Scale(SizeF factor);
    protected virtual Control.ControlCollection CreateControlsInstance();
    public virtual AnchorStyles Anchor { get; set; }
    public virtual Color BackColor { get; set; }
    public virtual BindingContext BindingContext { get; set; }
    public int Bottom { get; }
    public Rectangle Bounds { get; set; }
    public bool Capture { get; set; }
    public Rectangle ClientRectangle { get; }
    public Size ClientSize { get; set; }
    public virtual ContextMenu ContextMenu { get; set; }
    public Control.ControlCollection Controls { get; }
    public ControlBindingsCollection DataBindings { get; }
    public virtual DockStyle Dock { get; set; }
    public bool Enabled { get; set; }
    public virtual bool Focused { get; }
    public virtual Font Font { get; set; }
    public virtual Color ForeColor { get; set; }
    public IntPtr Handle { get; }
    public int Height { get; set; }
    public virtual bool InvokeRequired { get; }
    public bool IsDisposed { get; }
    public int Left { get; set; }
    public Point Location { get; set; }
    public static MouseButtons MouseButtons { get; }
    public static Point MousePosition { get; }
    public string Name { get; set; }
    public Control Parent { get; set; }
    public int Right { get; }
    protected virtual bool ScaleChildren { get; }
    public Size Size { get; set; }
    public int TabIndex { get; set; }
    public bool TabStop { get; set; }
    public object Tag { get; set; }
    public virtual string Text { get; set; }
    public int Top { get; set; }
    public Control TopLevelControl { get; }
    public bool Visible { get; set; }
    public int Width { get; set; }
    public event EventHandler Click;
    public event EventHandler DoubleClick;
    public event EventHandler EnabledChanged;
    public event EventHandler GotFocus;
    public event EventHandler HandleCreated;
    public event EventHandler HandleDestroyed;
    public event HelpEventHandler HelpRequested;
    public event KeyEventHandler KeyDown;
    public event KeyPressEventHandler KeyPress;
    public event KeyEventHandler KeyUp;
    public event EventHandler LostFocus;
    public event MouseEventHandler MouseDown;
    public event MouseEventHandler MouseMove;
    public event MouseEventHandler MouseUp;
    public event PaintEventHandler Paint;
    public event EventHandler ParentChanged;
    public event EventHandler Resize;
    public event EventHandler TextChanged;
    public event EventHandler Validated;
    public event CancelEventHandler Validating;
    public class ControlCollection : ArrangedElementCollection, IList, ICollection, IEnumerable
    {
      public ControlCollection(Control owner);
      public virtual void Add(Control value);
      int IList.Add(object control);
      public bool Contains(Control control);
      public int IndexOf(Control control);
      public virtual void Remove(Control value);
      void IList.Remove(object control);
      public void RemoveAt(int index);
      public virtual void Clear();
      public int GetChildIndex(Control child);
      public void SetChildIndex(Control child, int newIndex);
      public virtual Control this[int index] { get; }
    }
  }
}
