using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FirstMAUI.Models;

public class Scholarship : INotifyPropertyChanged
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Country { get; set; }
    public required string Level { get; set; }
    public required string Field { get; set; }
    public required string Description { get; set; }
    public required string DetailDescription { get; set; }
    public required string Deadline { get; set; }
    public bool IsVerified { get; set; }
    public bool IsFullScholarship { get; set; }
    public required string Status { get; set; } // e.g. "verified", "pending"
    public string PostedBy { get; set; } // optional

    public string Priviledges { get; set; } // optional

    public List<CommentAttached> Comments { get; set; } = new List<CommentAttached>();

    public string ScholarshipUrl { get; set; }

    public string ApplicationUrl { get; set; }

    private bool _isSaved = false;
    public bool IsSaved
    {
        get => _isSaved;
        set
        {
            if (_isSaved != value)
            {
                _isSaved = value;
                OnPropertyChanged();
            }
        }
    }

    public bool IsDeadlineSoon
    {
        get
        {
            if (DateTime.TryParse(Deadline, out var deadlineDate))
            {
                return deadlineDate <= DateTime.Now.AddMonths(1);
            }

            return false;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class CommentAttached
{
    public string PersonName { get; set; }
    public string Comment { get; set; }
    public string ApplyYear { get; set; }
}